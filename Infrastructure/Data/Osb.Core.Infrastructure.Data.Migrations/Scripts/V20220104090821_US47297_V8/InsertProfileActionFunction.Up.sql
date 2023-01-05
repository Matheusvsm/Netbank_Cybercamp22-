CREATE OR REPLACE FUNCTION public.insertprofileactionfunction(
	"paramProfileId" bigint,
    "paramActionFunctionId" bigint,
    "paramUserId" bigint)
    RETURNS TABLE("ProfileActionFunctionId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."ProfileActionFunction"
           (
	       	"ProfileId",
            "ActionFunctionId",
			"CreationDate",
			"UpdateDate",
			"CreationUserId",
			"UpdateUserId")
	VALUES (
		   "paramProfileId",
           "paramActionFunctionId",
		   now(),
           now(),
           "paramUserId",
		   "paramUserId")RETURNING "ProfileActionFunctionId"
$BODY$;

ALTER FUNCTION public.insertprofileactionfunction(bigint, bigint, bigint)
    OWNER TO "OSB";