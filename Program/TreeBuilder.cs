namespace Program
{
    class TreeBuilder
    {
        private TreeNode<Page> _home;
        public TreeNode<Page> RootNode => _home;
        private string[] _pages;
        public TreeBuilder(string[] pages)
        {
            _pages = pages;
            _home = new TreeNode<Page>(new Page(pages[0]));
            BuildTree(_pages);
        }
        public void BuildTree(string[] pages)
        {
            TreeNode<Page> prevPage = _home;
            TreeNode<Page> currentPage;

            for (int i = 1; i < pages.Length; i++)
            {
                int currentPageLevel = pages[i].Count(c => c == '.');
                int prevPageLevel = prevPage.getValue.getTitle.Count(c => c == '.');
                Page currentPageObject = new Page(pages[i]);

                if (currentPageLevel > prevPageLevel)
                {
                    currentPage = prevPage.AddChildNode(currentPageObject);
                }
                else
                {
                    for (int j = 0; j <= prevPageLevel - currentPageLevel; j++)
                    {
                        prevPage = prevPage.getParent;
                    }
                    currentPage = prevPage.AddChildNode(currentPageObject);
                }

                //Reseta prevPage
                prevPage = currentPage;
            }

        }

    }
}