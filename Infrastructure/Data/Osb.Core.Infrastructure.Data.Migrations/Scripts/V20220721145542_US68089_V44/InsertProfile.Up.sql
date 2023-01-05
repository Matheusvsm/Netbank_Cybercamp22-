DROP FUNCTION public.insertprofile(character varying, bigint);

CREATE FUNCTION public.insertprofile(
	"paramName" character varying,
	"paramUserId" bigint)
    RETURNS TABLE("ProfileId" bigint, "Name" text, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
INSERT INTO public."Profile"
           (
	       	"Name",
			"CreationDate",
			"UpdateDate",
			"CreationUserId",
			"UpdateUserId")
	VALUES (
		   "paramName",
		   now(),
           now(),
           "paramUserId",
		   "paramUserId")
	RETURNING 
			"ProfileId",
			"Name",
			"CreationDate",
			"UpdateDate",
			"DeletionDate",
			"CreationUserId",
			"UpdateUserId"
$BODY$;
ALTER FUNCTION public.insertprofile(character varying, bigint)
    OWNER TO "OSB";