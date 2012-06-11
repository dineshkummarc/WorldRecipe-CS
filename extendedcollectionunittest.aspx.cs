using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using XDRecipe.ExtendedCollections;

//This page is a unit test for ExrendedCollection.
//You can remove/delete this page anytime you want.

/// <summary>
/// Object in this class manages email properties
/// </summary>
public class Car
{
    //Defaut constructor
    public Car()
    {
    }

    public Car(string personname, int speed)
    {
        this._PersonName = personname;
        this._Speed = speed;
    }

    protected string _PersonName;
    protected int _Speed;


    public string PersonName
    {
        get { return _PersonName; }
        set { _PersonName = value; }
    }
    public int Speed
    {
        get { return _Speed; }
        set { _Speed = value; }
    }
}

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //This is the generic extended collection unit test page.
        //You can remove/delete this page anytime you want.

        ExtendedCollection<int> dinos = new ExtendedCollection<int>();
        ExtendedCollection<string> dinosaurs = new ExtendedCollection<string>();
        ExtendedCollection<string> MyList = dinosaurs;

        ExtendedCollection<string> mystring = new ExtendedCollection<string>();

        ExtendedCollection<string> mytest = new ExtendedCollection<string>();

        ExtendedCollection<string> mysublist = mystring.FindAll(EndsWithSaurus);

        ExtendedCollection<int> a = new ExtendedCollection<int>();

        a.Add(4);
        a.Add(2);
        a.Add(7);
        a.Add(95);
        a.Add(3);
        a.Add(45);
        a.Add(5);
        a.Add(6);
        a.Add(1);
        a.Add(9);
        a.Add(18);
        a.Add(29);
        a.SortAscending();
        //a.Reverse();
        //a.SortDescending();
        //a.ReplaceWithByItem(3, 10); 

        Response.Write("GetSumInt: " + a.GetSumInt(a.ToArray()).ToString() + "<br>");

        int[] myIntArray = a.ToArray();
        //int[] myArray = new int[] { 22, 10, 4, 6, 33, 7, 8, 9, 11, 35, 48, 64, 78 };

        Response.Write("GetMaxInt: " + a.GetMaxInt(myIntArray).ToString() + "<br>");
        Response.Write("GetMaxInt: " + a.GetMaxInt(a.ToArray()).ToString() + "<br>");
        Response.Write("GetMinInt: " + a.GetMinInt(a.ToArray()).ToString() + "<br>");

        ExtendedCollection<double> d = new ExtendedCollection<double>();

        d.Add(4.1);
        d.Add(6.2);
        d.Add(7.9);
        d.Add(15.8);
        d.Add(3.5);
        d.Add(45.6);
        d.Add(54.6);

        Response.Write("<br>");

        Response.Write("GetMinDouble: " + d.GetMinDouble(d.ToArray()).ToString() + "<br>");
        Response.Write("GetMaxDouble: " + d.GetMaxDouble(d.ToArray()).ToString() + "<br>");
        Response.Write("GetSumDouble: " + d.GetSumDouble(d.ToArray()).ToString() + "<br>");

        Response.Write("<br>");


        foreach (int s in a)
        {
            Response.Write(s.ToString() + "<br>");
        }

        Response.Write("<br>");

        ExtendedCollection<string> x = new ExtendedCollection<string>();
        x.Add("Hello");
        x.Add("There");
        x.Add("World");
        x.Add("Four");
        x.Add("Three");
        x.Add("Two");
        x.Add("One");

        ExtendedCollection<string> l = new ExtendedCollection<string>();
        l.Add("one");
        l.Add("two");
        l.Add("three");
        l.Add("four");
        l.Add("five");
        //l.TrimExcess();

        // B.
        string[] s1 = l.ToArray();

        Response.Write("ToArrayLenght = " + s1.Length.ToString() + "<br>");
        Response.Write("ToArrayGetValue = " + s1.GetValue(2).ToString() + "<br>");

        Response.Write("<br>");


        // Make a collection of Cars.
        ExtendedCollection<Car> myCars = new ExtendedCollection<Car>();
        myCars.Add(new Car("Rusty", 20));
        myCars.Add(new Car("Zippy", 90));
        myCars.Add(new Car("Rudy", 60));
        myCars.Add(new Car("Tom", 60));
        myCars.Add(new Car("Henry", 70));
        myCars.Add(new Car("Carl", 50));
        myCars.Add(new Car("Robert", 60));
        myCars.RemoveAt(1);
        myCars.RemoveAt(3);

        foreach (Car c in myCars)
        {
            Response.Write("PersonName: " + c.PersonName + " , Speed: " + c.Speed + "<br>");
        }

        Response.Write("<br>");

        Response.Write("<b>Removed Items History:</b>" + "<br>");
        foreach (Car cr in myCars.RemovedItemHistory)
        {
            Response.Write("PersonName: " + cr.PersonName + " , Speed: " + cr.Speed + "<br>");
        }

        Response.Write("<br>");
        Response.Write("RemoveItemCount: " + myCars.RemovedItemCounter.ToString() + "<br>");
        Response.Write("Exist: " + l.Exists(TestForLength5) + "<br>");
        Response.Write("Capacity: " + l.Capacity.ToString() + "<br>");
        Response.Write("TrueForAll = " + l.TrueForAll(TestForLength5) + "<br>");

        Response.Write("<br><br>");

        foreach (string s in x.FindAll(TestForLength5))
        {
            Response.Write(s.ToString() + "<br>");
        }

        Response.Write("<br>");

        /*
        mystring.Add("One");
        mystring.Add("Four");
        mystring.Add("Two");
        mystring.Add("Five");
        mystring.Add("Six");
        mystring.Add("Three");
        mystring.Sort();
         */

        mystring.Add("Compsognathus");
        mystring.Add("Testsaurus");
        mystring.Add("Amargasaurus");
        mystring.Add("Oviraptor");
        mystring.Add("Tsaurus");
        mystring.Add("Velociraptor");
        mystring.Add("Masasaurus");
        mystring.Add("Deinonychus");
        mystring.Add("Dilophosaurus");
        mystring.Add("Gallimimus");
        mystring.Add("Triceratops");
        mystring.Add("Sagasaurus");
        mystring.Add("Taurus");
        mystring.Add("Elephant");
        mystring.Add("Dragonsaurus");


        mytest.Add("One");
        mytest.Add("Two");
        mytest.Add("Three");
        mytest.Add("Four");
        mytest.Add("Five");
        mytest.Add("Six");
        mytest.Add("Seven");
        mytest.Add("Eight");
        mytest.Add("Nine");
        mytest.Add("Ten");

        mytest.ReplaceWithByIndex(1, "Test1");
        mytest.ReplaceWithByItem("Four", "Test2");

        Response.Write("<br>");
        foreach (string mt in mytest)
        {
            Response.Write(mt.ToString() + "<br>");
        }
        Response.Write("<br>");

        //mystring.RemoveRange(2, 2);

        //mystring.Reverse();
        //mystring.Reverse(1,4);

        string[] output = mystring.GetRange(2, 3).ToArray();
        foreach (string dinosaur in output)
        {
            Response.Write(dinosaur.ToString() + "<br>");
        }

        Response.Write("<br>");

        foreach (string st in mysublist)
        {
            Response.Write(st + "<br>");
        }

        Response.Write("<br>");

        foreach (string str in mystring)
        {
            Response.Write(str + "<br>");
        }

        Response.Write("<br>");
        Response.Write("GetValue mystring = " + mystring.GetValue(6).ToString() + "<br>");
        Response.Write("<br>");
        Response.Write("mystringcount = " + mystring.Count.ToString() + "<br>");
        Response.Write("GetValue = " + mystring[4] + "<br>");

        Response.Write("<br>");

        dinos.Add(1);
        dinos.Add(2);
        dinos.Add(3);
        dinos.Add(4);
        dinos.Add(5);
        dinos.Add(6);
        dinos.Remove(3);
        

        foreach (int i in dinos)
        {
            Response.Write(i + "<br>");
        }
    
        dinosaurs.Add("Compsognathus");
        dinosaurs.Add("Testsaurus");
        dinosaurs.Add("Amargasaurus");
        dinosaurs.Add("Oviraptor");
        dinosaurs.Add("Tsaurus");
        dinosaurs.Add("Velociraptor");
        dinosaurs.Add("Deinonychus");
        dinosaurs.Add("Dilophosaurus");
        dinosaurs.Add("Gallimimus");
        dinosaurs.Add("Triceratops");
        dinosaurs.Insert(2, "Arrarrathus");
        dinosaurs.ReplaceWithByIndex(2, "Test");
        dinosaurs.ReplaceWithByItem("Deinonychus", "Test2");
        dinosaurs.RemoveByItem("Velociraptor");
        dinosaurs.RemoveAt(5);

        Response.Write("<br>");
        for (int i = 0; i < dinosaurs.Count; i++)
        {
            //Response.Write(MyList[i].ToString() + "<br>");
            Response.Write(dinosaurs.GetValue(i).ToString() + "<br>");
        }

        Response.Write("<br>");
        foreach (string dinosaur in dinosaurs)
        {
            Response.Write(dinosaur.ToString() + "<br>");
        }
        
        Response.Write("<br>");
        Response.Write("Find = " + dinosaurs.Find(EndsWithSaurus) + "<br>");
        Response.Write("Dinosaurs count = " + dinosaurs.Count.ToString() + "<br>");
        Response.Write("FindIndexOf = " + dinosaurs.IndexOf("Amargasaurus").ToString() + "<br>");
        Response.Write("LastIndexOf = " + dinosaurs.FindLastIndexOf("Gallimimus") + "<br>");
        Response.Write("IndexOf = " + dinosaurs.IndexOf("Dilophosaurus") + "<br>");
        Response.Write("GetLastIndex = " + dinosaurs.GetLastIndex.ToString() + "<br>");
        Response.Write("GetValue = " + dinosaurs[7] + "<br>");
        Response.Write("GetFirstIndexValue = " + dinosaurs.GetFirstIndexValue.ToString() + "<br>");
        Response.Write("GetLastIndexValue = " + dinosaurs.GetLastIndexValue.ToString() + "<br>");
        Response.Write("GetIndexValue = " + dinosaurs.GetValue(6).ToString() + "<br>");
        Response.Write("TrueForAll = " + dinosaurs.TrueForAll(EndsWithSaurus) + "<br>");
        Response.Write("Contained Dilophosaurus = " + dinosaurs.Contains("Dilophosaurus"));

    }

    static bool TestForLength5(string x)
    {
        return x.Length == 5;
    }

    public static int ConvertFloatToInt(float x)
    {
        return Convert.ToInt32(x);
    }


    private static long IntToLongConverter(int i)
    {
        return i;
    }

    // Search predicate returns true if a string ends in "saurus".
    private static bool EndsWithSaurus(String s)
    {
        if ((s.Length > 5) &&
            (s.Substring(s.Length - 6).ToLower() == "saurus"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Search predicate returns true if a string ends in "saurus".
    private static bool EndsWithCrazy(String s)
    {
        if ((s.Length > 5) &&
            (s.Substring(s.Length - 6).ToLower() == "crazy"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static int CompareDinosByLength(string x, string y)
    {
        if (x == null)
        {
            if (y == null)
            {
                // If x is null and y is null, they're
                // equal. 
                return 0;
            }
            else
            {
                // If x is null and y is not null, y
                // is greater. 
                return -1;
            }
        }
        else
        {
            // If x is not null...
            //
            if (y == null)
            // ...and y is null, x is greater.
            {
                return 1;
            }
            else
            {
                // ...and y is not null, compare the 
                // lengths of the two strings.
                //
                int retval = x.Length.CompareTo(y.Length);

                if (retval != 0)
                {
                    // If the strings are not of equal length,
                    // the longer string is greater.
                    //
                    return retval;
                }
                else
                {
                    // If the strings are of equal length,
                    // sort them with ordinary string comparison.
                    //
                    return x.CompareTo(y);
                }
            }
        }

    }

}
