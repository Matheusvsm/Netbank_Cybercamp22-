CREATE OR REPLACE FUNCTION public.inserthashcode(
	"paramHashCode" character varying,
    "paramUserId" bigint
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."HashCode"
                    (                    
                    "HashCode",
                    "CreationDate",
                    "UpdateDate", 
                    "CreationUserId",
                    "UpdateUserId"                     
                     )
	VALUES (            
            "paramHashCode",
            now(),
            now(), 
            "paramUserId",
            "paramUserId"
           )
$BODY$;

ALTER FUNCTION public.inserthashcode(character varying, bigint)
    OWNER TO "OSB";
