namespace Task2
{
    public class FileManager
    {
        public static FileManager INSTANCE { get; } = new FileManager();
        
        public string OpenFile()
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select a file";
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : throw new Exception("No file selected");
        }
        public string SaveFile()
        {
            using SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Saving the result";
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : throw new Exception("No file selected");
        }
    }
}