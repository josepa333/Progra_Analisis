#ifndef LINKEDLIST_H
#define LINKEDLIST_H
#include "Node.h"
#include <stdexcept>
using namespace std;

template <typename E>
class LinkedList{
private:
    Node<E>* head;
    Node<E>* tail;
    Node<E>* current;
    int size;
    Node<E>* searchPrevious(Node<E>* pNode)
    {
        if(pNode == head){
                return NULL;
            }
            Node<E> *res = head;
            while(res->next != pNode){
                res = res->next;
            }
            return res;
    }
    Node<E>* searchNode(int i){
        current= head;
        int c= 0;
        while(current->next != NULL){
            if(c == i){
                return current->next;
            }
            current= current->next;
            c++;
        }
        return NULL;
    }
    void swapNodeElement(Node<E>* pNode1, Node<E>* pNode2){
        current= head;
        E element1= pNode1->element;
        E element2= pNode2->element;
        while(current->next != NULL){
            if(current->next == pNode1){
                current->next= new Node<E>(element2,current->next->next);
            }
            if(current->next == pNode2){
                current->next= new Node<E>(element1,current->next->next);
            }
            current= current->next;
        }
    }
public:
    LinkedList()
    {
        head = tail = current = new Node<E>(NULL);
        size = 0;
    }
    ~LinkedList()
    {
        clear();
        delete head;
    }
    void concat(LinkedList<E>& lista);
    void exchange(int pos1, int pos2);
    void insert(E pElement);
    void append(E pElement);
    E remove() throw(runtime_error);
    void reverse();
    void insertionSort()throw(runtime_error);
    void clear();
    E getElement() throw(runtime_error);
    E getGreatestElement() throw(runtime_error);
    void goToStart();
    void goToEnd();
    void goToPos(int nPos);
    void previous();
    void next();
    int getPos();  //Diferente a la de la presentacion
    int getSize();
};
    template<typename E>
    void LinkedList<E>::concat(LinkedList<E>& lista){
        for(lista.goToStart();lista.getPos()!=lista.getSize();lista.next()){
            append(lista.getElement());
        }
    }
    template <typename E>
    void LinkedList<E>::exchange(int pos1,int pos2){
        Node<E>* aux1= searchNode(pos1);
        Node<E>* aux2= searchNode(pos2);
        Node<E>* temp1= searchPrevious(aux1);
        Node<E>* temp2= aux1->next;
        Node<E>* temp3= searchPrevious(aux2);
        Node<E>* temp4= aux2->next;

        if(aux2 == tail){
            tail= aux1;
        }
        if(pos1 + 1 == pos2){
            aux1->next= temp4;

            aux2->next= aux1;
            temp1->next= aux2;
        }
        else{
            aux1->next= temp4;
            temp3 -> next = aux1;

            aux2->next= temp2;
            temp1 -> next = aux2;
        }
    }
    template <typename E>
    void LinkedList<E>::insert(E pElement)
    {
        current->next = new Node<E>(pElement, current->next);
            if(current == tail){
                tail = tail->next;
            }
            size++;
    }
    template <typename E>
    void LinkedList<E>::append(E pElement)
    {
        tail->next = new Node<E>(pElement, NULL);
            tail = tail->next;
            size++;
    }
    template <typename E>
    E LinkedList<E>::remove() throw(runtime_error)
    {
        if(current->next == NULL){
                throw runtime_error("No element to remove.");
            }
            E result = current->next->element;
            Node<E>* temp = current->next;
            current->next = current->next->next;
            if(temp == tail){
                tail = current;
            }
            delete temp;
            size--;
            return result;
    }
    template<typename E>
    void LinkedList<E>::reverse()
    {
        Node<E>* temp1;
        Node<E>* temp2;
        int c1= 0;
        int c2= size - 1;
        while(c1 < c2){
            temp1= searchNode(c1);
            temp2= searchNode(c2);
            swapNodeElement(temp1,temp2);
            c1++;
            c2--;
        }
        c2= size - 1;
        temp1= searchNode(c2);
        tail= temp1;
    }
    template <typename E>
    void LinkedList<E>::clear()
    {
        current = head;
            while(head != NULL){
                head = head->next;
                delete current;
                current = head;
            }
            head = tail = current = new Node<E>(NULL);
            size = 0;
    }
    template <typename E>
    E LinkedList<E>::getElement() throw(runtime_error)
    {
        if(current->next == NULL){
                throw runtime_error("No element to get.");
        }
        return current->next->element;
    }
    template <typename E>
    void LinkedList<E>::goToStart()
    {
        current = head;
    }
    template <typename E>
    void LinkedList<E>::goToEnd()
    {
        current = tail;
    }
    template <typename E>
    void LinkedList<E>::goToPos(int nPos)
    {
        if((nPos < 0) || (nPos > size)){
                throw runtime_error("Index out of bounds");
            }
            current = head;
            for(int i = 0; i < nPos; i++){
                current = current->next;
            }
    }
    template <typename E>
    void LinkedList<E>::previous()
    {
        if(current != head){
                current = searchPrevious(current);
            }
    }
    template <typename E>
    void LinkedList<E>::next()
    {
        if(current != tail){
            current = current->next;
        }
    }
    template <typename E>
    int LinkedList<E>::getPos()
    {
        int c= 0;
        Node<E>* temp= head;
        while(temp != current){
            temp= temp->next;
            c++;
        }
        return c;
    }
    template <typename E>
    int LinkedList<E>::getSize()
    {
        return size;
    }
    template <typename E>
    void LinkedList<E>::insertionSort()throw(runtime_error)
    {
        if(size == 0){
            throw runtime_error("List empty");
        }
        for(goToStart();getPos()!=getSize();next()){
            int pos= getPos();
            E element= getElement();
            for(goToStart();getPos()!=pos;next()){
                if(getElement() > element){
                    insert(element);
                    goToPos(pos + 1);
                    remove();
                    break;
                }
            }
            goToPos(pos);
        }
    }
    template <typename E>
    E LinkedList<E>::getGreatestElement()throw(runtime_error)
    {
        if(size == 0){
            throw runtime_error("List is empty");
        }
        current= head;
        E greatElement= current->next->element;
        E comparable;
        while(current->next != NULL){
            comparable= current->next->element;
            if(comparable > greatElement){
                greatElement= comparable;
            }
            current= current->next;
        }
        return greatElement;
    }

#endif // LINKEDLIST_H
