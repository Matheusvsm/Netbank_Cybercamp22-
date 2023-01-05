CREATE OR REPLACE FUNCTION public.insertusercredentiallog(
	"paramUserId" bigint,
	"paramLogin" character varying
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."UserCredentialLog"
                    (
					 "UserId",
	                 "Login",
					 "LogDate",
					 "CreationDate",
					 "UpdateDate",
				     "CreationUserId",
					 "UpdateUserId"
					 )
	VALUES (
		   "paramUserId",
           "paramLogin",
		   now(),
           now(),
		   now(),
           "paramUserId",
		   "paramUserId"
		   )
$BODY$;

ALTER FUNCTION public.insertusercredentiallog(bigint, character varying)
    OWNER TO "OSB";
