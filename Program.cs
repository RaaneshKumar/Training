/*  Check if the paswword is strong or not.
The password must contain atleast 6 characters.
The password must contain atleast one number.
The password must contain atleast one special character.
The password must contain atleast one uppercase and lowercase letters. */

Console.WriteLine ("Enter your password: ");
string password = Console.ReadLine ();
string numbers = "0123456789";
string special_char = "!@#$%^&*()-+";
if (password.Length >= 6 && digit () == true && special_character () == true && upper_case () == true && lower_case () == true) {
   Console.WriteLine ("Strong password.");
} else Console.WriteLine (weak_reason ());

bool digit () {
   foreach (char item in password) if (numbers.Contains (item)) return true;
   return false;
}

bool special_character () {
   foreach (char item in password) if (special_char.Contains (item)) return true;
   return false;
}

bool upper_case () {
   foreach (char item in password) if (char.IsUpper (item)) return true;
   return false;
}

bool lower_case () {
   foreach (char item in password) if (char.IsLower (item)) return true;
   return false;
}

string weak_reason () {
   string reason = "Your password is not strong.\n";
   if (password.Length < 6) reason += "Your password must contain atleast 6 characters.\n";
   if (lower_case () == false) reason += "Your password must contain atleast one lowercase letter.\n";
   if (upper_case () == false) reason += "Your password must contain atleast one uppercase letter.\n";
   if (special_character () == false) reason += "Your password must contain atleast one special character.\n";
   if (digit () == false) reason += "Your password must contain atleast one number.";
   return reason;
}