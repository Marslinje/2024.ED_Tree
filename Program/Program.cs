namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string wikiFile = @"Program\files\wiki.txt";
            string logFile = @"Program\files\log.txt";
            TreeNode<Page>? mostAccessedPage = null;

            Reader reader = new Reader();
            
            //Leitura de arquivos
            string[] wikiList = reader.ReadFile(wikiFile);
            string[] logList = reader.ReadFile(logFile);
            
            TreeBuilder treeBuilder = new TreeBuilder(wikiList); //Cria arvore a partir da wiki

            ReviewAccessLog(); //Atribui acesso do log aos nodes

            PrintMostAccessedPage(".Monsters");
            PrintMostAccessedPage(".Cards");

            #region Functions
            
            void PrintMostAccessedPage(string category)
            {
                treeBuilder.RootNode.ProcessPreOrder(node => GetMostAccessedPage(node, category));
                Console.WriteLine($"Most Accessed in {category}: {mostAccessedPage.getValue.getTitle} | {mostAccessedPage.getValue.getVisitCount}");
            }

            void GetMostAccessedPage(TreeNode<Page> node, string pageTypeName)
            {
                if (node.getParent?.getParent?.getValue?.getTitle == pageTypeName && (mostAccessedPage == null || node.getValue.getVisitCount > mostAccessedPage.getValue.getVisitCount))
                {
                    mostAccessedPage = node;
                }
            }

            void ReviewAccessLog()
            {
                int log = 1;
                foreach (var line in logList)
                {
                    Console.WriteLine($"Log {log}");
                    TreeNode<Page> node = treeBuilder.RootNode;
                    for(int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == 'b')
                        {
                            node = node.getParent;
                        }
                        else
                        {
                            node = node.getChildren[int.Parse(line[i].ToString())];
                        }

                        Console.Write($"[{line[i]}] {node.getValue.getTitle} ");
                        Console.WriteLine();
                        node.getValue.AddVisit();
                    }
                    log ++;
                }
            }

            #endregion
        }
    }
}