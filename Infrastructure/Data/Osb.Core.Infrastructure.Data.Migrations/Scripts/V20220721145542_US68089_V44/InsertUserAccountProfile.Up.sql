DROP FUNCTION IF EXISTS public.insertuseraccountprofile(bigint, bigint, bigint);

CREATE FUNCTION public.insertuseraccountprofile(
	"paramProfileId" bigint,
	"paramUserAccountId" bigint,
	"paramUserId" bigint)
    RETURNS TABLE("UserAccountProfileId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
INSERT INTO public."UserAccountProfile"
           (
			"ProfileId",
	       	"UserAccountId",
			"CreationDate",
			"UpdateDate",
			"DeletionDate",
			"CreationUserId",
			"UpdateUserId")
	VALUES (
		   "paramProfileId",
		   "paramUserAccountId",
		   now(),
           now(),
		   null,
           "paramUserId",
		   "paramUserId")
    RETURNING 
            "UserAccountProfileId"
$BODY$;
ALTER FUNCTION public.insertuseraccountprofile(bigint, bigint, bigint)
    OWNER TO "OSB";
