namespace Quiz.Models
{

    public static class CommonVariables
    {
        //Provides access to the current Microsoft.AspNetCore.Http.IHttpContextAccessor.HttpContext
        private static IHttpContextAccessor _httpContextAccessor;

        static CommonVariables()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }

        public static int? UserID()
        {
            //Initialize the UserID with null
            int? UserID = null;

            //check if session contains specified key?
            //if it contains then return the value contained by the key.
            if (_httpContextAccessor.HttpContext.Session.GetString("UserID") != null)
            {
                UserID = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserID").ToString());
            }
            return UserID;
        }

        public static string? UserName()
        {
            string? UserName = null;

            if (_httpContextAccessor.HttpContext.Session.GetString("UserName") != null)
            {
                UserName = _httpContextAccessor.HttpContext.Session.GetString("UserName").ToString();
            }
            return UserName;
        }
    }

}