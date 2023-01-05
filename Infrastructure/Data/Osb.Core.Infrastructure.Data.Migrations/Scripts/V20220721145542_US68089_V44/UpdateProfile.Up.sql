CREATE FUNCTION public.updateprofile(
	"paramName" character varying,
	"paramUserId" bigint,
	"paramProfileId" bigint)
    RETURNS TABLE("ProfileId" bigint, "Name" text, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
UPDATE  public."Profile"
	SET
	       	"Name" = "paramName",
			"UpdateDate" = now(),
			"UpdateUserId" =  "paramUserId"
	WHERE
			"ProfileId" = "paramProfileId" AND
			"DeletionDate" IS NULL
    RETURNING 
			"ProfileId",
			"Name",
			"CreationDate",
			"UpdateDate",
			"DeletionDate",
			"CreationUserId",
			"UpdateUserId"
$BODY$;
ALTER FUNCTION public.updateprofile(character varying, bigint, bigint)
    OWNER TO "OSB";
