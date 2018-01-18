using System;
namespace LiveVideoApp
{

    public class Responce
    {
        public bool Executed { get; set; }
        public object Result { get; set; }

        public static Responce ResponeNull()
        {
            Responce resp = new Responce();
            resp.Executed = false;
            resp.Result = null;

            return resp;
        }
    }

    public class Result
    {
        public bool LoggedIn { get; set; }
        public User User { get; set; }
        public string Details { get; set; }
    }
}