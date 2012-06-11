#region XD World Recipe V 2.8
// FileName: DBObj.cs
// Author: Dexter Zafra
// Date Created: 6/29/2008
// Website: www.ex-designz.net
#endregion
using System;

namespace XDRecipe.Model
{
    /// <summary>
    /// Object in this class manages CRUD database methods.
    /// </summary>
    public class DBObj : IDB
    {
        //Default constractor
        public DBObj()
        {
        }

#region Interface Member Implementation
        public virtual int Add() { return 0; } //Insert to database
        public virtual int Update() { return 0; } //Update to database
        public virtual int Delete() { return 0; } //Delete from database
        public virtual void fillup() { } //Fill up database fields
#endregion
    }
}
