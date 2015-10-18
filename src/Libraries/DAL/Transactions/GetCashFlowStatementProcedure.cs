using MixERP.Net.DbFactory;
using MixERP.Net.Framework;
using MixERP.Net.Framework.Extensions;
using PetaPoco;
using MixERP.Net.Entities.Transactions;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Schemas.Transactions.Data
{
    /// <summary>
    /// Prepares, validates, and executes the function "transactions.get_cash_flow_statement(_date_from date, _date_to date, _user_id integer, _office_id integer, _factor integer)" on the database.
    /// </summary>
    public class GetCashFlowStatementProcedure : DbAccess
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "transactions";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "get_cash_flow_statement";
        /// <summary>
        /// Login id of application user accessing this PostgreSQL function.
        /// </summary>
        public long _LoginId { get; set; }
        /// <summary>
        /// User id of application user accessing this table.
        /// </summary>
        public int _UserId { get; set; }
        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string _Catalog { get; set; }

        /// <summary>
        /// Maps to "_date_from" argument of the function "transactions.get_cash_flow_statement".
        /// </summary>
        public DateTime DateFrom { get; set; }
        /// <summary>
        /// Maps to "_date_to" argument of the function "transactions.get_cash_flow_statement".
        /// </summary>
        public DateTime DateTo { get; set; }
        /// <summary>
        /// Maps to "_user_id" argument of the function "transactions.get_cash_flow_statement".
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Maps to "_office_id" argument of the function "transactions.get_cash_flow_statement".
        /// </summary>
        public int OfficeId { get; set; }
        /// <summary>
        /// Maps to "_factor" argument of the function "transactions.get_cash_flow_statement".
        /// </summary>
        public int Factor { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "transactions.get_cash_flow_statement(_date_from date, _date_to date, _user_id integer, _office_id integer, _factor integer)" on the database.
        /// </summary>
        public GetCashFlowStatementProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "transactions.get_cash_flow_statement(_date_from date, _date_to date, _user_id integer, _office_id integer, _factor integer)" on the database.
        /// </summary>
        /// <param name="dateFrom">Enter argument value for "_date_from" parameter of the function "transactions.get_cash_flow_statement".</param>
        /// <param name="dateTo">Enter argument value for "_date_to" parameter of the function "transactions.get_cash_flow_statement".</param>
        /// <param name="userId">Enter argument value for "_user_id" parameter of the function "transactions.get_cash_flow_statement".</param>
        /// <param name="officeId">Enter argument value for "_office_id" parameter of the function "transactions.get_cash_flow_statement".</param>
        /// <param name="factor">Enter argument value for "_factor" parameter of the function "transactions.get_cash_flow_statement".</param>
        public GetCashFlowStatementProcedure(DateTime dateFrom, DateTime dateTo, int userId, int officeId, int factor)
        {
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
            this.UserId = userId;
            this.OfficeId = officeId;
            this.Factor = factor;
        }
        /// <summary>
        /// Prepares and executes the function "transactions.get_cash_flow_statement".
        /// </summary>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public string Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"GetCashFlowStatementProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            string query = "SELECT * FROM transactions.get_cash_flow_statement(@DateFrom, @DateTo, @UserId, @OfficeId, @Factor);";

            query = query.ReplaceWholeWord("@DateFrom", "@0::date");
            query = query.ReplaceWholeWord("@DateTo", "@1::date");
            query = query.ReplaceWholeWord("@UserId", "@2::integer");
            query = query.ReplaceWholeWord("@OfficeId", "@3::integer");
            query = query.ReplaceWholeWord("@Factor", "@4::integer");


            List<object> parameters = new List<object>();
            parameters.Add(this.DateFrom);
            parameters.Add(this.DateTo);
            parameters.Add(this.UserId);
            parameters.Add(this.OfficeId);
            parameters.Add(this.Factor);

            return Factory.Scalar<string>(this._Catalog, query, parameters.ToArray());
        }


    }
}