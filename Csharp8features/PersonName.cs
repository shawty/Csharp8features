// Step 1 - adding nullable enable turns the checks on
#nullable enable

public class PersonName
{
  public string FirstName { get; set; }
  // Step 3 - Forcing null ref values to be recognized by adding ?
  public string? MiddleName { get; set; }
  public string LastName { get; set; }

  // After step 1 first green squiggle will be here
  public PersonName(string firstName, string lastName)
  {
    FirstName = firstName;
    // Step 2 - setting the initial null will move the green squiggle to here
    MiddleName = null;
    LastName = lastName;
  }

  // Step 4 - Change get display name to the following coallese operator
  // the second option will now show green squiggle  indicating that one
  // route still has the potential to cause a null ref exception.
  // But as you now know this, using the middle name there can now be removed
  public string GetDisplayName() =>
    (!string.IsNullOrEmpty(MiddleName))
      ? $"{FirstName} {MiddleName[0]} {LastName}"
      : $"{FirstName} {MiddleName[0]} {LastName}";

}