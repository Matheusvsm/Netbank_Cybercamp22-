CREATE FUNCTION public.getprofilebyid(
	"paramProfileId" bigint)
    RETURNS TABLE("ProfileId" bigint, "Name" text, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
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
			"DeletionDate",
			"CreationUserId",
			"UpdateUserId"
FROM
			"Profile"
WHERE
			"ProfileId" = "paramProfileId" AND
			"DeletionDate" IS NULL
$BODY$;
ALTER FUNCTION public.getprofilebyid(bigint)
    OWNER TO "OSB";
