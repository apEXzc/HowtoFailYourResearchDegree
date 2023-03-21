using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

public class EventCardClick : MonoBehaviour
{
    public RoundButton roundButton;
    
    // context card effect
    public BlockFeatureEffect blockFeatureEffect;
    public RemoveFeatureEffect removeFeatureEffect;
    public FindCardFeatureEffect findCardFeatureEffect;
    
    // implemenation card effect
    public BlockImpFeatureEffect blockImpFeatureEffect;
    public RemoveImpFeatureEffect removeImpFeatureEffect;
    public ImpSpicalFeatureEffect ImpSpicalFeatureEffect;
    
    // write-up card effect
    public RemoveWriteUpFeatureEffect removeWriteUpFeatureEffect;
    public WriteUpSpecialEffect writeUpSpecialEffect;
    
    public RemindWindow remindWindow;
    public GameObject BgCover;
    public GameObject BgCover2;
    public GameObject BgCover3;
    
    public int effect = 0;
    
    public acceleratedMove effectMove;
    public acceleratedMove effectMove1;

    void Start()
    {
        remindWindow = GameObject.Find("remindWindow").GetComponent<RemindWindow>();
        roundButton = GameObject.Find("ButtonManager").GetComponent<RoundButton>();
        effectMove = GameObject.Find("CardSpcialEffect").GetComponent<acceleratedMove>();
        effectMove1 = GameObject.Find("effect2").GetComponent<acceleratedMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("BgCover") != null && gameObject.GetComponent<ShowCard>().card is EventContextCard){
            BgCover = GameObject.Find("BgCover");
        }
        else if (GameObject.Find("BgCover2") != null && gameObject.GetComponent<ShowCard>().card is EventImplementationCard)
        {
            BgCover2 = GameObject.Find("BgCover2");
        }
        else if (GameObject.Find("BgCover3") != null && gameObject.GetComponent<ShowCard>().card is EventWriteUpCard)
        {
            BgCover3 = GameObject.Find("BgCover3");
        }

        if (gameObject.GetComponent<ShowCard>().card is EventContextCard)
        {
            effect = checkCardEffect();
            if (effect == 1)
            {
                blockFeatureEffect = GameObject.Find("EventCardEffect").GetComponent<BlockFeatureEffect>();
            }
            else if (effect == 2)
            {
                removeFeatureEffect = GameObject.Find("EventCardEffect").GetComponent<RemoveFeatureEffect>();
            }
            else if (effect == 3)
            {
                findCardFeatureEffect = GameObject.Find("EventCardEffect").GetComponent<FindCardFeatureEffect>();
            }
        }
        else if (gameObject.GetComponent<ShowCard>().card is EventImplementationCard)
        {
            effect = checkCardEffect();
            if (effect == 4)
            {
                blockImpFeatureEffect = GameObject.Find("EventCardEffect").GetComponent<BlockImpFeatureEffect>();
            }
            else if (effect == 5)
            {
                removeImpFeatureEffect = GameObject.Find("EventCardEffect").GetComponent<RemoveImpFeatureEffect>();
            }
            else if (effect == 6)
            {
                ImpSpicalFeatureEffect = GameObject.Find("EventCardEffect").GetComponent<ImpSpicalFeatureEffect>();
            }
        }
        else if (gameObject.GetComponent<ShowCard>().card is EventWriteUpCard)
        {
            effect = checkCardEffect();
            if (effect == 7)
            {
                removeWriteUpFeatureEffect = GameObject.Find("EventCardEffect").GetComponent<RemoveWriteUpFeatureEffect>();
            }
            else if (effect == 8)
            {
                writeUpSpecialEffect = GameObject.Find("EventCardEffect").GetComponent<WriteUpSpecialEffect>();
            }
        }
    }

    public void OnClickButton()
    {
        //if (!remindWindow.remindClickEventOnebyOne())
        //{
        //    return;
        //}

        if (gameObject.GetComponent<ShowCard>().card is EventContextCard)
        {
            // check which card is clicked
            EventContextCard card = gameObject.GetComponent<ShowCard>().card as EventContextCard;
            if (gameObject == roundButton.EventContextCardObjects[2] && BgCover.activeInHierarchy)
            {
                BgCover.SetActive(false);
            }
            else if (gameObject == roundButton.EventContextCardObjects[2] && !BgCover.activeInHierarchy)
            {
                card = roundButton.EventContextCardObjects[1].GetComponent<ShowCard>().card as EventContextCard;
                effectMove.Click(gameObject,new Vector2(430, 0));
                gameObject.GetComponent<Button>().enabled = false;
                roundButton.EventImplementationCardPool.gameObject.SetActive(false);
            }
            else if (gameObject == roundButton.EventContextCardObjects[1])
            {
                card = roundButton.EventContextCardObjects[0].GetComponent<ShowCard>().card as EventContextCard;
                roundButton.EventWriteUpCardPool.gameObject.SetActive(false);
                effectMove.Click(gameObject,new Vector2(430, 0));
                effectMove1.Click(roundButton.EventContextCardObjects[2].gameObject,new Vector2(860, 0));
                gameObject.GetComponent<Button>().enabled = false;
                roundButton.EventContextCardObjects[0].GetComponent<Button>().enabled = false;
            }
            
            //execute the effect of the card
            if (effect == 1)
            {
                blockFeatureEffect.ContextCardEffect(card.effect);
            }
            else if (effect == 2)
            {
                removeFeatureEffect.ContextRemoveCardEffect(card.effect);
            }
            else if (effect == 3)
            {
                findCardFeatureEffect.ContextCardEffect(card.effect);
            }
        }

        if (gameObject.GetComponent<ShowCard>().card is EventImplementationCard)
        {
            // check which card is clicked
            EventImplementationCard card = gameObject.GetComponent<ShowCard>().card as EventImplementationCard;
            if (gameObject == roundButton.EventImpCardObjects[2] && BgCover2.activeInHierarchy)
            {
                BgCover2.SetActive(false);
            }
            else if (gameObject == roundButton.EventImpCardObjects[2] && !BgCover2.activeInHierarchy)
            {
                card = roundButton.EventImpCardObjects[1].GetComponent<ShowCard>().card as EventImplementationCard;
                effectMove.Click(gameObject,new Vector2(-430, 0));
                gameObject.GetComponent<Button>().enabled = false;
                roundButton.EventContextCardPool.gameObject.SetActive(false);
            }
            else if (gameObject == roundButton.EventImpCardObjects[1])
            {
                card = roundButton.EventImpCardObjects[0].GetComponent<ShowCard>().card as EventImplementationCard;
                roundButton.EventWriteUpCardPool.gameObject.SetActive(false);
                effectMove.Click(gameObject,new Vector2(430, 0));
                gameObject.GetComponent<Button>().enabled = false;
                roundButton.EventImpCardObjects[0].GetComponent<Button>().enabled = false;
            }
            
            //execute the effect of the card
            if (effect == 4)
            {
                blockImpFeatureEffect.ImpCardEffect(card.effect);
            }
            else if (effect == 5)
            {
                removeImpFeatureEffect.ImpCardEffect(card.effect);
            }
            else if (effect == 6)
            {
                ImpSpicalFeatureEffect.ImpCardEffect(card.effect);
            }
        }

        if (gameObject.GetComponent<ShowCard>().card is EventWriteUpCard)
        {
            // check which card is clicked
            EventWriteUpCard card = gameObject.GetComponent<ShowCard>().card as EventWriteUpCard;
            if (gameObject == roundButton.EventWriteUpObjects[2] && BgCover3.activeInHierarchy)
            {
                BgCover3.SetActive(false);
            }
            else if (gameObject == roundButton.EventWriteUpObjects[2] && !BgCover3.activeInHierarchy)
            {
                card = roundButton.EventWriteUpObjects[1].GetComponent<ShowCard>().card as EventWriteUpCard;
                effectMove.Click(gameObject,new Vector2(-430, 0));
                gameObject.GetComponent<Button>().enabled = false;
                roundButton.EventImplementationCardPool.gameObject.SetActive(false);
            }
            else if (gameObject == roundButton.EventWriteUpObjects[1])
            {
                card = roundButton.EventWriteUpObjects[0].GetComponent<ShowCard>().card as EventWriteUpCard;
                roundButton.EventContextCardPool.gameObject.SetActive(false);
                effectMove.Click(roundButton.EventWriteUpObjects[2].gameObject,new Vector2(-860, 0));
                effectMove1.Click(gameObject,new Vector2(-430, 0));
                gameObject.GetComponent<Button>().enabled = false;
                roundButton.EventWriteUpObjects[0].GetComponent<Button>().enabled = false;
            }

            //execute the effect of the card
            if (effect == 7)
            {
                removeWriteUpFeatureEffect.WriteUpCardEffect(card.effect);
            }
            else if (effect == 8)
            {
                writeUpSpecialEffect.WriteUpCardEffect(card.effect);
            }
            
        }
    }

    public int checkCardEffect()
    {
        GameObject currentCard = gameObject;
        for (int i = 0; i < 3; i++)
        {
            if (gameObject.GetComponent<ShowCard>().card is EventContextCard)
            {
                //context
                if (gameObject == roundButton.EventContextCardObjects[2] && BgCover.activeInHierarchy)
                {
                    break;
                }
                else if (gameObject == roundButton.EventContextCardObjects[2] && !BgCover.activeInHierarchy)
                {
                    currentCard = roundButton.EventContextCardObjects[1];
                }
                else if (gameObject == roundButton.EventContextCardObjects[1])
                {
                    currentCard = roundButton.EventContextCardObjects[0];
                } 
            }
            else if (gameObject.GetComponent<ShowCard>().card is EventImplementationCard)
            {
                if (gameObject == roundButton.EventImpCardObjects[2] && BgCover2.activeInHierarchy)
                {
                    break;
                }
                else if (gameObject == roundButton.EventImpCardObjects[2] && !BgCover2.activeInHierarchy)
                {
                    currentCard = roundButton.EventImpCardObjects[1];
                }
                else if (gameObject == roundButton.EventImpCardObjects[1])
                {
                    currentCard = roundButton.EventImpCardObjects[0];
                }
            }
            else if (gameObject.GetComponent<ShowCard>().card is EventWriteUpCard)
            {
                if (gameObject == roundButton.EventWriteUpObjects[2] && BgCover3.activeInHierarchy)
                {
                    break;
                }
                else if (gameObject == roundButton.EventWriteUpObjects[2] && !BgCover3.activeInHierarchy)
                {
                    currentCard = roundButton.EventWriteUpObjects[1];
                }
                else if (gameObject == roundButton.EventWriteUpObjects[1])
                {
                    currentCard = roundButton.EventWriteUpObjects[0];
                }
            }
        }
        if (currentCard.GetComponent<ShowCard>().card is EventContextCard)
        {
            EventContextCard card = currentCard.GetComponent<ShowCard>().card as EventContextCard;
            if (card.effect == "writersblock" || card.effect == "litreviewparadox" || card.effect == "shoddynotes")
            {
                return 1;
            }
            else if (card.effect == "bluescreen"
                     || card.effect == "distraction"
                     || card.effect == "distraction2"
                     || card.effect == "dotoomuch"
                     || card.effect == "hasmybook"
                     || card.effect == "loandelay"
                     || card.effect == "lostenthus"
                     || card.effect == "tunnelvision"
                     || card.effect == "sick"
                     || card.effect == "sisterwedding"
                     || card.effect == "sourcesfail"
                     || card.effect == "advicespecialist"
                     || card.effect == "mentorleaves")
            {
                return 2;
            }
            else if (card.effect == "advicefromacademic" || card.effect == "sourceswin")
            {
                return 3;
            }
        }
        else if (currentCard.GetComponent<ShowCard>().card is EventImplementationCard)
        {
            EventImplementationCard card = currentCard.GetComponent<ShowCard>().card as EventImplementationCard;
            if (card.effect == "supervisorsick")
            {
                return 4;
            }
            else if(card.effect == "bluescreen" ||
                    card.effect == "brokenfridge" ||
                    card.effect == "cantuseit" ||
                    card.effect == "competition" ||
                    card.effect == "distraction" ||
                    card.effect == "dotoomuch" ||
                    card.effect == "ethics" ||
                    card.effect == "fire" ||
                    card.effect == "flood" ||
                    card.effect == "lostenthus" ||
                    card.effect == "metadatafail" ||
                    card.effect == "philosophy" ||
                    card.effect == "procrastinate" ||
                    card.effect == "resources" ||
                    card.effect == "sick" ||
                    card.effect == "sisterwedding" ||
                    card.effect == "statistics" ||
                    card.effect == "theory" ||
                    card.effect == "tunnelvision")
            {
                return 5;
            }
            else if (card.effect == "relevance")
            {
                return 6;
            }
        }
        else if (currentCard.GetComponent<ShowCard>().card is EventWriteUpCard)
        {
            EventWriteUpCard card = currentCard.GetComponent<ShowCard>().card as EventWriteUpCard;
            if ( card.effect == "bibliography" ||
                 card.effect == "brotherswedding" ||
                 card.effect == "references" ||
                 card.effect == "tunnelvision" ||
                 card.effect == "bluescreen" ||
                 card.effect == "doesitwork" ||
                 card.effect == "ethics" ||
                 card.effect == "lostenthus" ||
                 card.effect == "sick" ||
                 card.effect == "distraction" ||
                 card.effect == "distraction2" ||
                 card.effect == "dotoomuch" ||
                 card.effect == "fitforpurpose" ||
                 card.effect == "disagreement" ||
                 card.effect == "sowhat" ||
                 card.effect == "waffle" ||
                 card.effect == "jargon" ||
                 card.effect == "lostvoice" ||
                 card.effect == "procrastinate" ||
                 card.effect == "regurgitation" ||
                 card.effect == "uncriticalwriting")
            {   
                return 7;
            }
            else if (card.effect == "proofreader")
            {
                return 8;
            }
        }
        return 0;
    }
    
    
    
}