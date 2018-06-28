using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    /// <summary>
    /// 币种类别
    /// </summary>
    public enum AccountType
    {
        云盾 = 1,
        云图 = 2
    };

}

namespace Library
{
    public class AccountTypeHelper
    {
        public static string GetName(int type)
        {
            return Enum.GetName(typeof(AccountType), type);
        }
    }
}


