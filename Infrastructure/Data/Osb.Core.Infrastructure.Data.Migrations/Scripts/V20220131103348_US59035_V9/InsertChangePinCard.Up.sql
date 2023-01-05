DROP FUNCTION public.insertchangepincard(character varying, bigint, bigint, character varying, character varying, character varying, integer, character varying, bigint);

CREATE OR REPLACE FUNCTION public.insertchangepincard(
	"paramIdentifierCard" character varying,	
	"paramAccountId" bigint,
    "paramOperationId" bigint,
	"paramCurrentPin" character varying,
	"paramPin" character varying,
	"paramConfirmationPin" character varying,
	"paramStatus" integer,
	"paramSalt" character varying,
    "paramUserId" bigint
    )
    RETURNS TABLE ("ChangePinCardId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."ChangePinCard"
                    (                     
                     "IdentifierCard",					 
                     "AccountId",
                     "OperationId",
                     "CurrentPin",                     
                     "Pin",
                     "ConfirmationPin",
                     "Salt",
					 "Status",
					 "CreationDate",
                     "UpdateDate",
                     "CreationUserId",
                     "UpdateUserId"
                     )
    VALUES (
		    "paramIdentifierCard",            
            "paramAccountId",
            "paramOperationId",
            "paramCurrentPin",
            "paramPin", 
            "paramConfirmationPin",
            "paramSalt",
		    "paramStatus",
            NOW(),
            NOW(),
            "paramUserId",
            "paramUserId"
            ) RETURNING "ChangePinCardId";
$BODY$;

ALTER FUNCTION public.insertchangepincard(character varying, bigint, bigint, character varying, character varying, character varying, integer, character varying, bigint)
    OWNER TO "OSB";

