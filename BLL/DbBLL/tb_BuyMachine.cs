﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public partial class tb_BuyMachine
    {
        public DataSet GetListByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount, string FindKey)
        {
            return dal.GetListByPage(UserID, PageIndex, PageSize, out PageCount, out TotalCount, FindKey);
        }
    }
}
