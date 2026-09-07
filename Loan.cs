using System;
public class Loan
{
    public int MemberId { get; set; }
    public string Isbn { get; set; } = "";
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsReturned { get; set; }
    public int ExtensionCount { get; set; }
}
