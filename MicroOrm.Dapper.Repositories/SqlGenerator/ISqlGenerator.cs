﻿using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MicroOrm.Dapper.Repositories.SqlGenerator
{
    /// <summary>
    ///     Universal SqlGenerator for Tables
    /// </summary>
    public interface ISqlGenerator<TEntity> where TEntity : class
    {
        /// <summary>
        ///     All original properties
        /// </summary>
        PropertyInfo[] AllProperties { get; }

        /// <summary>
        ///     Has Date of changed
        /// </summary>
        bool HasUpdatedAt { get; }

        /// <summary>
        ///     Date of Changed Property
        /// </summary>
        PropertyInfo UpdatedAtProperty { get; }

        /// <summary>
        ///     Sql provider
        /// </summary>
        ESqlConnector SqlConnector { get; set; }

        /// <summary>
        ///     Is Autoincrement table
        /// </summary>
        bool IsIdentity { get; }

        /// <summary>
        ///     Table Name
        /// </summary>
        string TableName { get; }

        /// <summary>
        ///     Identity Metadata property
        /// </summary>
        SqlPropertyMetadata IdentitySqlProperty { get; }

        /// <summary>
        ///     Keys Metadata sql properties
        /// </summary>
        SqlPropertyMetadata[] KeySqlProperties { get; }

        /// <summary>
        ///     Metadata sql properties
        /// </summary>
        SqlPropertyMetadata[] SqlProperties { get; }

        /// <summary>
        ///     Has Logical delete
        /// </summary>
        bool LogicalDelete { get; }

        /// <summary>
        ///     PropertyName of Status
        /// </summary>
        string StatusPropertyName { get; }

        /// <summary>
        ///     Logical delete Value
        /// </summary>
        object LogicalDeleteValue { get; }

        /// <summary>
        ///     Get SQL for INSERT Query
        /// </summary>
        SqlQuery GetInsert(TEntity entity);

        /// <summary>
        ///     Get SQL for UPDATE Query
        /// </summary>
        SqlQuery GetUpdate(TEntity entity);

        /// <summary>
        ///     Get SQL for SELECT Query
        /// </summary>
        SqlQuery GetSelectFirst(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        ///     Get SQL for SELECT Query
        /// </summary>
        SqlQuery GetSelectAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        ///     Get SQL for SELECT Query with BETWEEN
        /// </summary>
        SqlQuery GetSelectBetween(object from, object to, Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> expression = null);

        /// <summary>
        ///     Get SQL for DELETE Query
        /// </summary>
        SqlQuery GetDelete(TEntity entity);
    }
}