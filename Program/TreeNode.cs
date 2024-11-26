public class TreeNode<Type>
{
    private Type _value;
    public Type getValue => _value;
    private List<TreeNode<Type>>? _children = new List<TreeNode<Type>>();
    public List<TreeNode<Type>> getChildren => _children;
    private TreeNode<Type> _parent;
    public TreeNode<Type> getParent => _parent;

    public TreeNode(Type value, TreeNode<Type>? parent = null)
    {
        _value = value;
        _parent = parent;
    }
    public TreeNode<Type> AddChildNode(Type _value)
    {
        //Cria novo node como child do node atual recebendo _value e o adiciona a _children do node atual
        TreeNode<Type> newNode = new TreeNode<Type>(_value, this);
        _children.Add(newNode);
        return newNode;

    }
    public void AssignParentNode(TreeNode<Type> node)
    {
        _parent = node;
    }
    public void ProcessPreOrder(Action<TreeNode<Type>> function)
    {
        function(this);
        foreach (var child in _children)
        {
            child.ProcessPreOrder(function);
        }
    }

}