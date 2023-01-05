DROP FUNCTION public.insertuser(character varying, integer);

CREATE OR REPLACE FUNCTION public.insertuser(
	"paramLogin" character varying,
	"paramStatus" integer,
	"paramIsFirstAccess" boolean)
    RETURNS TABLE ("UserId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."User"
                    (
	                 "Login",			
					 "Status",
					 "IsFirstAccess",
					 "CreationDate",
					 "UpdateDate"
					 )
			VALUES (
					"paramLogin",
					"paramStatus",
					"paramIsFirstAccess",
					now(),
					now()
					) RETURNING "UserId"
$BODY$;

ALTER FUNCTION public.insertuser(character varying, integer, boolean)
    OWNER TO "OSB";
