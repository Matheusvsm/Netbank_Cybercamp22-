CREATE FUNCTION public.getprofilebynameanduserid(
	"paramName" character varying,
	"paramUserId" bigint)
    RETURNS TABLE("ProfileId" bigint, "Name" text, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT
			"ProfileId",
			"Name",
			"CreationDate",
			"UpdateDate",
			"CreationUserId",
			"UpdateUserId"
FROM
			"Profile"
WHERE
			"Name" = "paramName" AND
			"CreationUserId" = "paramUserId" AND
			"DeletionDate" IS NULL
$BODY$;
ALTER FUNCTION public.getprofilebynameanduserid(character varying, bigint)
    OWNER TO "OSB";