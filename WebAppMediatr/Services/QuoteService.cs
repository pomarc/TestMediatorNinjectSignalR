using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppMediatr.Models;
using MediatR;
using WebAppMediatr.Messages;

namespace WebAppMediatr.Services
{
    public class QuoteService:IRequestHandler<QuotesGetQuotesRequest,List<Quote>>
    {
        public List<Quote> GetQuotes()
        {
            List<Quote> quotes = new List<Quote>();
            quotes.Add(new Quote
            {
                Id = 0,
                Car = "meriva",
                Price = 1200
            });
            quotes.Add(new Quote
            {
                Id = 1,
                Car = "meriva plus",
                Price = 5200
            });
            quotes.Add(new Quote
            {
                Id =2,
                Car = "aygo",
                Price = 52
            });
            quotes.Add(new Quote
            {
                Id = 3,
                Car = "rava",
                Price = 8500
            });
            quotes.Add(new Quote
            {
                Id = 4,
                Car = "fava",
                Price = 1200
            });

            return quotes;

        }

        public List<Quote> GetQuotes(int id)
        {
            List<Quote> quotes = new List<Quote>();
            quotes.Add(new Quote
            {
                Id = 0,
                Car = "meriva",
                Price = 1200
            });
            quotes.Add(new Quote
            {
                Id = 1,
                Car = "meriva plus",
                Price = 5200
            });
            quotes.Add(new Quote
            {
                Id = 2,
                Car = "aygo",
                Price = 52
            });
            quotes.Add(new Quote
            {
                Id = 3,
                Car = "rava",
                Price = 8500
            });
            quotes.Add(new Quote
            {
                Id = 4,
                Car = "fava",
                Price = 1200
            });

            return quotes;

        }



        List<Quote> IRequestHandler<QuotesGetQuotesRequest, List<Quote>>.Handle(QuotesGetQuotesRequest message)
        {
            if (message.Id != 0)
            {
                return GetQuotes(message.Id);
            }
            else
            {
                return GetQuotes();
            }
           
        }
    }
}