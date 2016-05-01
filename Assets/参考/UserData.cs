using System;
using System.Collections.Generic;
using System.Text;


    public class UserData
    {
        static UserData g_this;
        public static UserData Instance()
        {
            if(g_this==null)
            {
                g_this = new UserData();
            }
            return g_this;
        }

        private UserData()
        {
            dataTemp = new MyJson.JsonNode_Object();
            dataSavedForApp = new MyJson.JsonNode_Object();
            dataSavedForUser = new MyJson.JsonNode_Object();
        }
        public void LoadUserData()
        {

        }
        public void SaveUserData()
        {

        }
        public MyJson.JsonNode_Object dataTemp//全局临时数据
        {
            get;
            private set;
        }
        public MyJson.JsonNode_Object dataSavedForApp//需要存档的程序数据
        {
            get;
            private set;
        }
        public MyJson.JsonNode_Object dataSavedForUser//需要存档的用户数据
        {
            get;
            private set;
        }
    }

