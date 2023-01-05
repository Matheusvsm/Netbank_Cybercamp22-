CREATE OR REPLACE FUNCTION public.getoperationbyoperationidandoperationtype(
	"paramOperationId" bigint,
	"paramOperationType" integer
	)
    RETURNS TABLE(
		"OperationId" bigint, 
		"OperationType" integer, 
		"ExternalIdentifier" bigint, 
		"CreationDate" timestamp without time zone, 
		"UpdateDate" timestamp without time zone, 
		"DeletionDate" timestamp without time zone, 
		"CreationUserId" bigint, 
		"UpdateUserId" bigint
	) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT
        O."OperationId",
        O."OperationType",
		CASE
			WHEN "paramOperationType" = 3 THEN MT."ExternalIdentifier"
			WHEN "paramOperationType" = 6 THEN IT."ExternalIdentifier"
			WHEN "paramOperationType" = 40 THEN PO."ExternalIdentifier"
			ELSE NULL
			END AS "ExternalIdentifier",
        O."CreationDate", 
		O."UpdateDate",
		O."DeletionDate", 
		O."CreationUserId", 
		O."UpdateUserId"
    FROM
        PUBLIC."Operation" O
		LEFT JOIN "MoneyTransfer" MT ON O."OperationId" = MT."OperationId"
		LEFT JOIN "InternalTransfer" IT ON O."OperationId" = IT."OperationId"
		LEFT JOIN "PixOut" PO ON O."OperationId" = PO."OperationId"
    WHERE 
        O."OperationId" = "paramOperationId"
		AND O."OperationType" = "paramOperationType"
    AND
        O."DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getoperationbyoperationidandoperationtype(bigint, integer)
    OWNER TO "OSB";