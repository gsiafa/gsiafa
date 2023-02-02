namespace gsiafa.Configuration
{
    using gsiafa.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Text.RegularExpressions;

    namespace Identity.IdentityPolicy
    {
        public class CustomPasswordPolicy : PasswordValidator<User>
        {
            public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
            {
                IdentityResult result = await base.ValidateAsync(manager, user, password);
                List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();
                int MinLength = 8;
                if (password.ToLower().Contains(user.UserName.ToLower()))
                {
                    errors.Add(new IdentityError
                    {
                        Description = "Password cannot contain username/email"
                    });
                }
                
                //check if password is empty or less than 8 charachters minimum
                if (String.IsNullOrEmpty(password) || password.Length < MinLength)
                {
                    errors.Add(new IdentityError
                    {
                        Description = "Password should be at least " + MinLength + " characters minimum length"
                    });
                }
                
                // if password is 8 characters or more, it should contains at least 3 characters from any of these groups
                int counter = 0;
                List<string> patterns = new List<string> {
                @"[a-z]",          // lowercase
                @"[A-Z]",          // uppercase
                @"[0-9]",          // digits
                @"[!@#$%^&*\(\)_\+\-\={}<>,\.\|""'~`:;\\?\/\[\] ]" // special symbols, including white space
                };

                // count type of different chars in password
                foreach (string p in patterns)
                {
                    if (Regex.IsMatch(password, p))
                    {
                        counter++;
                    }
                }
                if (counter < 3)
                {
                    errors.Add(new IdentityError
                    {
                        Description = "Password must contain at least 1 character from at least 3 of these groups: lowercase(a-z), Uppercase(A-Z), Digits (0-9) and special character. "
                    });                    
                }
                return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
            }
        }
    }
}
