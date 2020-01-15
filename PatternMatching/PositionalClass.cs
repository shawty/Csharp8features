namespace PatternMatching
{
  public class PositionalClass
  {
    private readonly string _forename;
    private readonly string _surname;
    private readonly int _category;

    // For property matching, you match on property name and
    // contents, so you need public properties on the data/class
    // your using.
    public string Forename { get { return _forename; } }
    public string Surname { get { return _surname; } }
    public int Category { get { return _category; } }

    public PositionalClass(string forename, string surname, int category)
    {
      _forename = forename;
      _surname = surname;
      _category = category;
    }

    // If you want to use positional matching and expose private members
    // without the risk of them being properties, then you need to create
    // a Deconstruct method that returns only the properties you want to
    // match on.
    //
    // 1) IT MUST Be called Deconstruct
    // 2) Parameters MUST be passed as OUT
    //
    // It's called positional pattern matching beacuse it's the order
    // the outs are presented in that tells the compiler what your matching
    // on, not the name or anything else.
    public void Deconstruct(
      out string forename,
      out string surname,
      out int category
    )
    {
      forename = _forename;
      surname = _surname;
      category = _category;
    }

  }
}
