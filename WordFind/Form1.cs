using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WordFind
{
    public partial class Main : Form
    {
        private static readonly HashSet<string> ReservedKeywords = new HashSet<string>
{
    "if", "else", "else if","for", "while", "do", "switch", "case", "default", "break",
    "continue", "return", "try", "catch", "finally", "throw", "new", "this",
    "typeof", "instanceof", "void", "delete", "in", "of", "import", "export", "class",
    "interface", "enum", "type", "namespace",
    "yield", "await", "async",
    "extends", "implements", "package", "super","class"
};
        private string? selectedExtension;
        public Main()
        {
            InitializeComponent();

            txtSelectedFile.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            txtSelectedFile.ReadOnly = false;

            txtSearchBar.PlaceholderText = "Enter search criteria";


            cmbFileType.Items.AddRange(new string[] { "*.*", "*.js", "*.txt", "*.ts", "*.java", "*.cs", "*.htm", "*.c", "*.cpp", "*.py" });

            gridResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridResult.Visible = false;
            if (gridResult.Columns.Count == 0)
            {
                gridResult.Columns.Add("FileName", "File Name");
                gridResult.Columns.Add("FilePath", "File Path");
                gridResult.Columns.Add("FolderName", "Folder Name");
                gridResult.Columns.Add("LineNumber", "Line Number");
                gridResult.Columns.Add("MethodName", "Method Name");
            }
            gridResult.ReadOnly = true;

            pbStatus.Minimum = 0;
            pbStatus.Maximum = 100;
            pbStatus.Visible = false;
            pbStatus.Step = 1;
            pbStatus.Style = ProgressBarStyle.Continuous;

            BtnDownload.Visible = false;

            BrowseButton.Click += BrowseButton_Click;
            BtnFindAll.Click += BtnFindAll_Click;
            BtnDownload.Click += BtnCopyToFile_Click;
        }

        private void BtnFindAll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchBar.Text))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            var strRootFolderPath = txtSelectedFile.Text.Trim();
            gridResult.Rows.Clear();

            try
            {
                if (cmbFileType.SelectedItem != null)
                {
                    selectedExtension = cmbFileType.SelectedItem.ToString();
                    if (!selectedExtension.StartsWith("*."))
                    {
                        selectedExtension = "*." + selectedExtension;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a file type from the combo box.");
                    return;
                }
                pbStatus.Visible = true;
                string searchPattern = "*" + selectedExtension;
                string[] files = Directory.GetFiles(strRootFolderPath, searchPattern, SearchOption.AllDirectories);
                var intTotalFiles = files.Length;
                var intProcessFiles = 0;
                UpdateProgress(intProcessFiles, intTotalFiles);

                foreach (string file in files)
                {
                    string fileExtension = Path.GetExtension(file).ToLower();
                    fileExtension = "*" + fileExtension;
                    string[] strLines = File.ReadAllLines(file);
                    var strCurrentMethodName = "";
                    for (int i = 0; i < strLines.Length; i++)
                    {
                        if (IsMethodStart(strLines[i], fileExtension))
                        {
                            strCurrentMethodName = ExtractMethodName(strLines[i], fileExtension);
                        }

                        if (strLines[i].Contains(txtSearchBar.Text))
                        {
                            gridResult.Rows.Add(
                                Path.GetFileName(file),
                                Path.GetDirectoryName(file),
                                Path.GetFileName(Path.GetDirectoryName(file)),
                                i + 1,
                                strCurrentMethodName
                            );
                        }
                    }
                    intProcessFiles++;
                    UpdateProgress(intProcessFiles, intTotalFiles);
                }
                MessageBox.Show("File Processing Complete");
                pbStatus.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Searching files: {ex.Message}");
            }

            gridResult.Visible = true;
            BtnDownload.Visible = true;
        }

        private bool IsMethodStart(string strLine, string fileExtension)
        {
            strLine = strLine.Trim();

            if (fileExtension.Equals("*.ts", StringComparison.OrdinalIgnoreCase) || fileExtension.Equals("*.js", StringComparison.OrdinalIgnoreCase))
            {
                return IsScriptMethodStart(strLine);
            }

            return ((strLine.StartsWith("def ") || strLine.StartsWith("function") || strLine.StartsWith("void") || strLine.StartsWith("int") || strLine.StartsWith("boolean") || strLine.StartsWith("string") ||
             strLine.StartsWith("public ") || strLine.StartsWith("private ") || strLine.StartsWith("protected ") || strLine.StartsWith("internal ") ||
             strLine.StartsWith("static ") || strLine.StartsWith("virtual ") || strLine.StartsWith("abstract ") || strLine.StartsWith("public synchronized ") ||
             strLine.StartsWith("private synchronized "))
            && (strLine.Contains("(") && !strLine.Contains("=")));
        }

        private bool IsScriptMethodStart(string strLine)
        {
            bool isMethodLine = strLine.Contains("(") && strLine.Contains(")") && (strLine.Contains("{"));
            bool isArrowFunction = strLine.Contains("=>");
            if (isArrowFunction)
            {
                return !strLine.Contains(":") && !strLine.Contains(".") && strLine.Contains("=>") && !StartsWithReservedKeyword(strLine);
            }
            return isMethodLine && !strLine.Contains("=>") && !strLine.Contains(".") && !strLine.Contains("else if") && !StartsWithReservedKeyword(strLine);
        }

        private bool StartsWithReservedKeyword(string strLine)
        {
            string firstWord = strLine.Split(new[] { ' ', '(','{' }, StringSplitOptions.RemoveEmptyEntries)[0];
            return ReservedKeywords.Contains(firstWord);
        }

        private string ExtractMethodName(string strLine, string fileExtension)
        {
            strLine = strLine.Trim();

            if (fileExtension.Equals("*.ts", StringComparison.OrdinalIgnoreCase) || fileExtension.Equals("*.js", StringComparison.OrdinalIgnoreCase))
            {
                return ExtractScriptMethodName(strLine);
            }

            string[] parts = strLine.Split('(');
            string[] methodNameParts = parts[0].Split(' ');
            return methodNameParts[^1];
        }

        private string ExtractScriptMethodName(string strLine)
        {
            if (strLine.Contains("=>"))
            {
                // const fn = () => {
                string[] parts = strLine.Split("=>");
                string[] parts1 = parts[0].Split("=");
                string[] partstrim = parts1[0].Trim().Split(' ');
                return partstrim[^1];
            }
            else
            {
                string[] parts = strLine.Split('(');
                string methodNamePart = parts[0].Trim();
                string[] methodNameParts = methodNamePart.Split(' ');
                return methodNameParts[^1];
            }
        }


        private void UpdateProgress(int intCrntFileIndex, int intTotalFiles)
        {
            double ProgPercentage = ((double)intCrntFileIndex / intTotalFiles) * 100;
            int progval = (int)ProgPercentage;
            progval = Math.Max(pbStatus.Minimum, Math.Min(pbStatus.Maximum, progval));
            pbStatus.Value = progval;
        }

        private void CopySearchResultToFile()
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataGridViewRow row in gridResult.Rows)
            {
                if (row.Cells.Count >= gridResult.ColumnCount && row.Cells[0].Value != null &&
                    row.Cells[1].Value != null &&
                    row.Cells[2].Value != null &&
                    row.Cells[3].Value != null &&
                    row.Cells[4].Value != null)
                {
                    string? fileName = row.Cells[0].Value.ToString();
                    string? filePath = row.Cells[1].Value.ToString();
                    string? folderName = row.Cells[2].Value.ToString();
                    string? lineNumber = row.Cells[3].Value.ToString();
                    string? methodName = row.Cells[4].Value.ToString();

                    sb.AppendLine("File Name - " + fileName);
                    sb.AppendLine("File Path - " + filePath);
                    sb.AppendLine("Folder Name - " + folderName);
                    sb.AppendLine("Line Number - " + lineNumber);
                    sb.AppendLine("Method Name - " + methodName);
                    sb.AppendLine();
                }
            }

            saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); ;
            saveFile.Filter = "Text File|*.txt";
            saveFile.Title = "Save Search Result";
            saveFile.ShowDialog();

            if (saveFile.FileName != "")
            {
                using (StreamWriter writer = new StreamWriter(saveFile.FileName))
                {
                    writer.Write(sb.ToString());
                }
            }
        }

        private void BtnCopyToFile_Click(object sender, EventArgs e)
        {
            if (gridResult.Rows.Count == 0)
            {
                MessageBox.Show("No search result to copy.");
                return;
            }

            CopySearchResultToFile();
            MessageBox.Show("Search result copied to file successfully.");
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            {
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    DialogResult result = folderDialog.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                    {
                        txtSelectedFile.Text = folderDialog.SelectedPath;
                    }
                }

            }
        }
    }
}