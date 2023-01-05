CREATE OR REPLACE FUNCTION public.insertuseraccountprofile(
	"paramUserAccountId" bigint,
	"paramProfileId" bigint,
	"paramUserId" bigint)
    RETURNS TABLE("UserAccountProfileId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."UserAccountProfile"
           (
	       	"UserAccountId",			
			"ProfileId",
			"CreationDate",
			"UpdateDate",
			"CreationUserId",
			"UpdateUserId")
	VALUES (
		   "paramUserAccountId",
		   "paramProfileId",
		    now(),
           	now(),
           	"paramUserId",
		    "paramUserId")RETURNING "UserAccountProfileId"
$BODY$;

ALTER FUNCTION public.insertuseraccountprofile(bigint, bigint, bigint)
    OWNER TO "OSB";