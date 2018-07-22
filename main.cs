using System;
using Com.Expload;
using System.Collections.Generic;

[Program]
class CardsProgram {
  public Mapping<Bytes, List<String>> OwnerToCards = new Mapping<Bytes, List<String>>();
  public Mapping<Bytes, int> OwnerToRate = new Mapping<Bytes, int>();
  public Mapping<Bytes, List<Bytes>> TournirToPersons = new Mapping<Bytes, List<Bytes>>();

  public List<String> GetCardsOwner(Bytes owner) {
    List<String> l = new List<String>();
    return OwnerToCards.getDefault(owner, l);
  }

  public void AddCard(Bytes owner, String cardName) {
    if (OwnerToCards.exists(owner)) {
      List<String> userCards = OwnerToCards.get(owner);
      userCards.Add(cardName);
    } else {
      AddOwner(owner);
      AddCard(owner, cardName);
    }
  }
  
  public void AddOwner(Bytes owner) {
    if (!OwnerToCards.exists(owner)) {
      List<String> l = new List<String>();
      OwnerToCards.put(owner, l);
      OwnerToRate.put(owner, 0);
    }
  }
  
  public int GetOwnerRate(Bytes owner) {
    if (!OwnerToRate.exists(owner)) {
      AddOwner(owner);
      return 0;
    }
    return OwnerToRate.get(owner);
  }

  public void SetOwnerRate(Bytes owner, int rate) {
    if (!OwnerToRate.exists(owner)) {
      AddOwner(owner);
    }
    OwnerToRate.put(owner, rate);
  }

  public void AddOwnerToTournir(Bytes owner, Bytes tournir) {
    List<Bytes> tournirPersons = TournirToPersons.get(tournir);
    tournirPersons.Add(owner);
  }

}

class MainClass { 
  public static void Main() {
  } 
}
