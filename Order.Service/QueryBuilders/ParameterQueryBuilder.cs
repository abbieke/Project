namespace Project.Service
{
    /// <summary>
    /// 參數表 QueryBuilder
    /// </summary>
    public class ParameterQueryBuilder
    {
        /// <summary>
        /// 建構子
        /// </summary>
        public ParameterQueryBuilder()
        {
        }

        /// <summary>
        /// 取得查詢參數表 Sql
        /// </summary>
        /// <returns>Sql</returns>
        public string GetParametersSql()
        {
            return @"
                    SELECT
                            parameter_id        AS Id            ,
                            parameter_key       AS ParameterKey  ,
                            parameter_value     AS Value         ,
                            parameter_updatedat AS UpdatedAt
                    FROM
                            parameter
                    WHERE
                            parameter_key = @Key";
        }

        /// <summary>
        /// 取得新增參數表 Sql
        /// </summary>
        /// <returns>Sql</returns>
        public string GetInsertParameterSql()
        {
            return @"
                    INSERT INTO
                            parameter
                            (
                                    parameter_key  ,
                                    parameter_value,
                                    parameter_updatedat
                            )
                            VALUES
                            (
                                    @ParameterKey  ,
                                    @Value,
                                    @UpdatedAt
                            )";
        }

        /// <summary>
        /// 取得更新參數表 Sql
        /// </summary>
        /// <returns>Sql</returns>
        public string GetUpdateParameterSql()
        {
            return @"
                    UPDATE
                            parameter
                    SET
                            parameter_value     = @Value,
                            parameter_updatedat = @UpdatedAt";
        }
    }
}