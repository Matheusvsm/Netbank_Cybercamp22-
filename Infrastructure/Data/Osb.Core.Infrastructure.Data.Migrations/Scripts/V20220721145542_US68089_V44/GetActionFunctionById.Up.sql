CREATE FUNCTION public.getactionfunctionbyid(
	"paramActionFunctionId" bigint)
    RETURNS TABLE("ActionFunctionId" bigint, "Action" character varying, "Controller" character varying, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT
		"ActionFunctionId",
		"Action",
		"Controller",
		"CreationDate",
		"UpdateDate",
		"DeletionDate",
		"CreationUserId",
		"UpdateUserId"
FROM 
		"ActionFunction"
WHERE
		"ActionFunctionId" = "paramActionFunctionId"
		AND "DeletionDate" IS NULL
$BODY$;
ALTER FUNCTION public.getactionfunctionbyid(bigint)
    OWNER TO "OSB";