CREATE OR REPLACE FUNCTION public.insertprofileuifunction(
	"paramProfileId" bigint,
    "paramUIFunctionId" bigint,
    "paramUserId" bigint)
    RETURNS TABLE("ProfileUIFunctionId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."ProfileUIFunction"
           (
	       	"ProfileId",
            "UIFunctionId",
			"CreationDate",
			"UpdateDate",
			"CreationUserId",
			"UpdateUserId")
	VALUES (
		   "paramProfileId",
           "paramUIFunctionId",
		   now(),
           now(),
           "paramUserId",
		   "paramUserId")RETURNING "ProfileUIFunctionId"
$BODY$;

ALTER FUNCTION public.insertprofileuifunction(bigint, bigint, bigint)
    OWNER TO "OSB";