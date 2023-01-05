CREATE OR REPLACE FUNCTION public.insertuser(
	"paramLogin" character varying,
	"paramStatus" integer)
    RETURNS TABLE ("UserId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."User"
                    (
	                 "Login",			
					 "Status",
					 "CreationDate",
					 "UpdateDate"
					 )
			VALUES (
					"paramLogin",
					"paramStatus",
					now(),
					now()
					) RETURNING "UserId"
$BODY$;

ALTER FUNCTION public.insertuser(character varying, integer)
    OWNER TO "OSB";
