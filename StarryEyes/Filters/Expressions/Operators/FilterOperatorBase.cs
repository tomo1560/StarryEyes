﻿using System;
using System.Collections.Generic;
using StarryEyes.Breezy.DataModel;

namespace StarryEyes.Filters.Expressions.Operators
{
    public abstract class FilterOperatorBase : FilterExpressionBase
    {
        public abstract IEnumerable<FilterExpressionType> SupportedTypes { get; }

        public virtual Func<TwitterStatus, bool> GetBooleanValueProvider()
        {
            throw new FilterQueryException("Unsupported transforms to boolean.", ToQuery());
        }

        public virtual Func<TwitterStatus, long> GetNumericValueProvider()
        {
            throw new FilterQueryException("Unsupported transforms to numeric.", ToQuery());
        }

        public virtual Func<TwitterStatus, string> GetStringValueProvider()
        {
            throw new FilterQueryException("Unsupported transforms to string.", ToQuery());
        }

        public virtual Func<TwitterStatus, IReadOnlyCollection<long>> GetSetValueProvider()
        {
            throw new FilterQueryException("Unsupported transforms to set.", ToQuery());
        }
    }

    public abstract class FilterSingleValueOperator : FilterOperatorBase
    {
        public FilterOperatorBase Value { get; set; }

        public override void BeginLifecycle()
        {
            Value.BeginLifecycle();
        }

        public override void EndLifecycle()
        {
            Value.EndLifecycle();
        }
    }

    public abstract class FilterTwoValueOperator : FilterOperatorBase
    {
        public FilterOperatorBase LeftValue { get; set; }

        public FilterOperatorBase RightValue { get; set; }

        public override string ToQuery()
        {
            return LeftValue.ToQuery() + " " + OperatorString + " " + RightValue.ToQuery();
        }

        protected abstract string OperatorString { get; }

        public override void BeginLifecycle()
        {
            LeftValue.BeginLifecycle();
            RightValue.BeginLifecycle();
        }

        public override void EndLifecycle()
        {
            LeftValue.EndLifecycle();
            RightValue.EndLifecycle();
        }
    }
}
