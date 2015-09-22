﻿using Automation.Models;
using Nancy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automation.Modules
{
    public class ChoreModule : NancyModule
    {
        public ChoreModule()
        {
            var recurrenceTest = new ChoreRecurrence(DateTime.Now, "day", 7);
            foreach (var date in recurrenceTest)
            {
                Console.WriteLine(date.ToShortDateString());
                System.Diagnostics.Debugger.Break();
            }
        }

        public List<ChoreGroup> GetChoresForDate(DateTime date)
        {
            var result = new List<ChoreGroup>();


            return result;
        }
        
        public class ChoreRecurrence : IEnumerable<DateTime>, IEnumerator<DateTime>
        {
            private DateTime startDate;
            private string recurrence;
            private int recurrenceCount;

            public ChoreRecurrence(DateTime startDate, string recurrence, int recurrenceCount)
            {
                this.startDate = startDate;
                this.recurrence = recurrence;
                this.recurrenceCount = recurrenceCount;
            }

            private DateTime currentDateTime = DateTime.MinValue;

            public bool MoveNext()
            {
                // IEnumerator specifies that we start before the first element in the collection
                if (currentDateTime == DateTime.MinValue)
                {
                    currentDateTime = startDate;
                }
                else
                {
                    switch (recurrence)
                    {
                        case "year":
                            currentDateTime = currentDateTime.AddYears(1 * recurrenceCount);
                            break;
                        case "quarter":
                            currentDateTime = currentDateTime.AddMonths(3 * recurrenceCount);
                            break;
                        case "month":
                            currentDateTime = currentDateTime.AddMonths(1 * recurrenceCount);
                            break;
                        case "dayofyear":
                            currentDateTime = currentDateTime.AddDays(1 * recurrenceCount);
                            break;
                        case "day":
                            currentDateTime = currentDateTime.AddDays(1 * recurrenceCount);
                            break;
                        case "week":
                            currentDateTime = currentDateTime.AddDays(7 * recurrenceCount);
                            break;
                        case "hour":
                            currentDateTime = currentDateTime.AddHours(1 * recurrenceCount);
                            break;
                        case "minute":
                            currentDateTime = currentDateTime.AddMinutes(1 * recurrenceCount);
                            break;
                        case "second":
                            currentDateTime = currentDateTime.AddSeconds(1 * recurrenceCount);
                            break;
                        case "millisecond":
                            currentDateTime = currentDateTime.AddMilliseconds(1 * recurrenceCount);
                            break;
                        case "microsecond":
                            throw new NotSupportedException("Sub-millisecond recurrence types are not supported");
                        case "nanosecond":
                            throw new NotSupportedException("Sub-millisecond recurrence types are not supported");
                        default:
                            throw new NotSupportedException("Recurrence type not recognized");
                    }
                }
                return true;
            }

            public DateTime Current
            {
                get
                {
                    return currentDateTime;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Reset()
            {
                currentDateTime = DateTime.MinValue;
            }

            public IEnumerator<DateTime> GetEnumerator()
            {
                return this;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Dispose()
            {

            }

        }
    }
}