/*  Check if the paswword is strong or not.
The password must contain atleast 6 characters.
The password must contain atleast one number.
The password must contain atleast one special character.
The password must contain atleast one uppercase and lowercase letters. */

using System.Text;

Console.WriteLine ("Enter your password: ");
string password = Console.ReadLine ();
string specialCharacter = "!@#$%^&*()-+";
if (password.Length >= 6) {
   StringBuilder weakReason = new ("Your password must contain atleast ");
   if (!password.Any (char.IsDigit)) weakReason.Append ("one digit, ");
   if (!password.Any (char.IsUpper)) weakReason.Append ("one uppercase letter, ");
   if (!password.Any (char.IsLower)) weakReason.Append ("one lowercase letter, ");
   if (!password.Any (x => specialCharacter.Contains (x))) weakReason.Append ("one special character !@#$%^&*()-+");
   if (weakReason.ToString () == "Your password must contain atleast ") Console.WriteLine ("Strong Password.");
   else Console.WriteLine (weakReason);
} else Console.WriteLine ("Your password must contain atleast six letters.");