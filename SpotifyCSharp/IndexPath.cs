namespace SpotifyCSharp
{

    // Used to help us find which items in the array was interacted with on the UI.
    public class IndexPath
    {
        private int section;
        private int row;

        public IndexPath(int section, int row)
        {
            this.section = section;
            this.row = row;
        }
        public int Section
        {
            get
            {
                return section;
            }
        }

        public int Row
        {
            get
            {
                return row;
            }
        }
    }
}
