DROP FUNCTION public.insertinactivatecard(character varying, bigint, bigint, character varying, character varying, integer, integer, bigint);

CREATE OR REPLACE FUNCTION public.insertinactivatecard(
	"paramIdentifierCard" character varying,
	"paramAccountId" bigint,
	"paramOperationId" bigint,
	"paramPin" character varying,
	"paramSalt" character varying,
	"paramReasonCode" integer,
	"paramStatus" integer,
	"paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."InactivateCard"
                    (
	                 "IdentifierCard",
					 "AccountId",
					 "OperationId",
					 "Pin",
					 "Salt",
				     "ReasonCode",
					 "Status",
					 "CreationDate",
    				 "UpdateDate",
					 "CreationUserId",
					 "UpdateUserId")
			 VALUES (
					 "paramIdentifierCard",
				 	 "paramAccountId",
					  "paramOperationId",
					 "paramPin",
					 "paramSalt",
					 "paramReasonCode",
					 "paramStatus",
			 		 Now(),
			 	     Now(),
			 		 "paramUserId",
			 		 "paramUserId")
$BODY$;

ALTER FUNCTION public.insertinactivatecard(character varying, bigint, bigint, character varying, character varying, integer, integer, bigint)
    OWNER TO "OSB";