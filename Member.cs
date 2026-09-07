using System;
using System.Collections.Generic;
public class Member
{
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public int ID { get; set; }
    public string PhoneNumber { get; set; } = "";
    public List<Loan> Loans { get; set; } = new();
    public DateTime? BlockedUntil { get; set; }
}
