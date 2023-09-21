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
   var weakReason = new StringBuilder ("Your password must contain atleast ");
   bool isStrong = true;
   if (!password.Any (char.IsDigit)) { isStrong = false; weakReason.Append ("one digit, "); }
   if (!password.Any (char.IsUpper)) { isStrong = false; weakReason.Append ("one uppercase letter, "); }
   if (!password.Any (char.IsLower)) { isStrong = false; weakReason.Append ("one lowercase letter, "); }
   if (!password.Any (specialCharacter.Contains)) { isStrong = false; weakReason.Append ($"one special character {specialCharacter}"); }
   Console.WriteLine (isStrong ? "Strong Password." : weakReason);
} else Console.WriteLine ("Your password must contain atleast six letters.");