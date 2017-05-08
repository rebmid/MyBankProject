using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// EmpID is used to identify the employee

public class Part : IEquatable<Part>, IComparable<Part>
{
    public string EmpName { get; set; }

    public int EmpID { get; set; }

    public override string ToString()
    {
        return "ID: " + EmpID + "   Name: " + EmpName;
    }
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        Part objAsPart = obj as Part;
        if (objAsPart == null) return false;
        else return Equals(objAsPart);
    }
    public int SortByNameAscending(string name1, string name2)
    {

        return name1.CompareTo(name2);
    }

    // Default comparer for Part type.
    public int CompareTo(Part comparePart)
    {
        // A null value means that this object is greater.
        if (comparePart == null)
            return 1;

        else
            return this.EmpID.CompareTo(comparePart.EmpID);
    }
    public override int GetHashCode()
    {
        return EmpID;
    }
    public bool Equals(Part other)
    {
        if (other == null) return false;
        return (this.EmpID.Equals(other.EmpID));
    }
    // Should also override == and != operators.

}
public class Example
{
    public static void Main()
    {
        // Create a list of parts.
        List<Part> parts = new List<Part>();

        // Add parts to the list.
        parts.Add(new Part() { EmpName = "Manoj", EmpID = 1434 });
        parts.Add(new Part() { EmpName = "Ashini", EmpID = 1234 });
        parts.Add(new Part() { EmpName = "Kevin", EmpID = 1634 }); ;
        // Name intentionally left null.
        parts.Add(new Part() { EmpID = 1334 });
        parts.Add(new Part() { EmpName = "Jeff", EmpID = 1444 });
        parts.Add(new Part() { EmpName = "Bob", EmpID = 1534 });


        // Write out the parts in the list. This will call the overridden 
        // ToString method in the Part class.
        Console.WriteLine("\nBefore sort:");
        foreach (Part aPart in parts)
        {
            Console.WriteLine(aPart);
        }


        // Call Sort on the list. This will use the 
        // default comparer, which is the Compare method 
        // implemented on Part.
        parts.Sort();


        Console.WriteLine("\nAfter sort by part number:");
        foreach (Part aPart in parts)
        {
            Console.WriteLine(aPart);
        }

        // This shows calling the Sort(Comparison(T) overload using 
        // an anonymous method for the Comparison delegate. 
        // This method treats null as the lesser of two values.
        parts.Sort(delegate (Part x, Part y)
        {
            if (x.EmpName == null && y.EmpName == null) return 0;
            else if (x.EmpName == null) return -1;
            else if (y.EmpName == null) return 1;
            else return x.EmpName.CompareTo(y.EmpName);
        });

        Console.WriteLine("\nAfter sort by name:");
        foreach (Part aPart in parts)
        {
            Console.WriteLine(aPart);
        }


    }
}
