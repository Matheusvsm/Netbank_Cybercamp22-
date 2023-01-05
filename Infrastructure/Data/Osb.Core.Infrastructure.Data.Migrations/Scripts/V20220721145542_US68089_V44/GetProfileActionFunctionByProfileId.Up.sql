
CREATE FUNCTION public.getprofileactionfunctionbyprofileid(
	"paramProfileId" bigint)
    RETURNS TABLE("ProfileActionFunctionId" bigint, "ProfileId" bigint, "ActionFunctionId" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT
		"ProfileActionFunctionId",
		"ProfileId",
		"ActionFunctionId",
		"CreationDate",
		"UpdateDate",
		"DeletionDate",
		"CreationUserId",
		"UpdateUserId"
FROM 
		"ProfileActionFunction"
WHERE
		"ProfileId" = "paramProfileId" AND
		"DeletionDate" IS NULL
$BODY$;
ALTER FUNCTION public.getprofileactionfunctionbyprofileid(bigint)
    OWNER TO "OSB";