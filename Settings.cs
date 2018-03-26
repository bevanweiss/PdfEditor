namespace PDFCleaner
{
    public struct Settings
    {
        public struct RemoveJavascript
        {
            public bool Enabled;
        }
        public struct ReplaceText
        {
            public bool Enabled;
            public string RegexMatch;
            public string RegexReplace;
        }
    }
}
