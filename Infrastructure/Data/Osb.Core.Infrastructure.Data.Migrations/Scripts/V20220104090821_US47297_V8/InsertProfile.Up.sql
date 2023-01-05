CREATE OR REPLACE FUNCTION public.insertprofile(
	"paramName" character varying,
	"paramUserId" bigint)
    RETURNS TABLE("ProfileId" bigint) 
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
		   "paramUserId")RETURNING "ProfileId"
$BODY$;

ALTER FUNCTION public.insertprofile(character varying, bigint)
    OWNER TO "OSB";