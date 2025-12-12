using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Repository
{
    public static class SpecEvaluator<T> where T:BaseEntity
    {

        public static IQueryable<T> GetQuery (IQueryable<T> inputQuery , ISpecification<T> spec)
        {
            //1.
            var Query = inputQuery;
            //2.
            if(spec.Criteria is not null)
            {
                Query = Query.Where(spec.Criteria);
            }
            //3.
            Query = spec.Includes.Aggregate(Query,(currentQuery,IncludeExpr) => currentQuery.Include(IncludeExpr));
            return Query;
        }
    }
}
