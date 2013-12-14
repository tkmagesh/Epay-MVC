using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using System.Collections;


namespace TicketManagement.Models
{
    public class TicketList : IEnumerable<Ticket>, IEnumerator<Ticket> {
        
        private List<Ticket> _list = new List<Ticket>();

        public void Add(Ticket ticket) {
            var newId = _list.Any() ? _list.Max(t => t.Id) + 1 : 1;
            ticket.Id = newId;
            _list.Add(ticket);
        }

        public IEnumerator<Ticket> GetEnumerator()
        {
            return this;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this;
        }

        int index = -1;
        public Ticket Current
        {
            get {
                return (Ticket)_list[index];
            }
        }

        public void Dispose()
        {
            
        }

        object System.Collections.IEnumerator.Current
        {
            get { return this.Current; }
        }

        public bool MoveNext()
        {
            index++;
            if (index >= _list.Count) {
                Reset();
                return false;
            }
            return true;
        }

        public void Reset()
        {
            index = -1;
        }
    }

    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketType Type { get; set; }
        public bool IsClosed { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ClosedOn { get; private set; }

        public Ticket()
        {
            this.CreatedOn = DateTime.Now;
        }
        public void Close() {
            this.IsClosed = true;
            this.ClosedOn = DateTime.Now;
        }
    }


public abstract class EnumBaseType<T> where T : EnumBaseType<T>
{
    protected static List<T> enumValues = new List<T>();

    public readonly int Key;
    public readonly string Value;

    public EnumBaseType(int key, string value)
    {
        Key = key;
        Value = value;
        enumValues.Add((T)this);
    }

    protected static ReadOnlyCollection<T> GetBaseValues()
    {
        return enumValues.AsReadOnly();
    }

    protected static T GetBaseByKey(int key)
    {
        foreach (T t in enumValues)
        {
            if(t.Key == key) return t;
        }
        return null;
    }
    
    public override string ToString()
    {
    return Value;
    }
}

public class TicketType : EnumBaseType<TicketType>
{
    public static readonly TicketType Technical = new TicketType(1, "Technical");
    public static readonly TicketType Operational = new TicketType(2, "Operational");
    public static readonly TicketType Salary = new TicketType(3, "Salary");
    public static readonly TicketType Others = new TicketType(4, "Others");

    public TicketType(int key, string value)
        : base(key, value)
    {
    }

    public static ReadOnlyCollection<TicketType> GetValues()
    {
        return GetBaseValues();
    }

    public static TicketType GetByKey(int key)
    {
        return GetBaseByKey(key);
    }
}
}