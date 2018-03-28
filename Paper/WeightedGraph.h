#ifndef WEIGHTEDGRAPH_H
#define WEIGHTEDGRAPH_H
#include <vector>
#include <queue>
#include "Vertex.h"
#include "LinkedList.h"
#include <math.h>
#include <cstdlib>
#include <ctime>


using namespace std;


class WeightedGraph
{
private:
    static const int NULL_EDGE = 0;
    vector<Vertex*> vertices;
    vector<bool> marks;			// marks[i] is mark for vertices[i]
    int nmbVertices;
    int maxVertices;
    vector< vector<int> > edges;
    int rows;
    int columns;

    LinkedList<int> getNeighbors(int v){
        LinkedList<int> output;
        for(int w= first(v); w != nmbVertices; w= next(v, w)){
            output.append(w);
        }
        return output;
    }

public:
    WeightedGraph(int pRows= 20, int pColumns= 30)
        {
            rows= pRows;
            columns= pColumns;
            int size= rows * columns;
            nmbVertices = 0;
			maxVertices = size;

			vertices.resize(size);
			for (int i=0;i<size;i++)	// init vertices
				vertices[i] = NULL;

			marks.resize(size);

			int rows = size;
			int columns = size;
            edges.resize(rows, vector<int>(columns, 0));
        }

    ~WeightedGraph()
        {
            for(int i= 0; i < nmbVertices; i++)
            {
                delete vertices[i];
            }
        }

    int getRows(){
        return rows;
    }

    int getColumns(){
        return columns;
    }

    bool is_empty()
        {
			if (nmbVertices == 0)
				return true;
			else
				return false;
		}

    bool is_full()
		{
			if (nmbVertices == maxVertices)
				return true;
			else
				return false;
		}

    void add_vertex(Vertex* aVertex) throw (runtime_error)
		{
		    if(is_full()){
                throw runtime_error("Graph is full.");
		    }
			vertices[nmbVertices] = aVertex;
			for (int i=0; i<maxVertices; i++)
			{
				edges[nmbVertices][i] = NULL_EDGE;
				edges[i][nmbVertices] = NULL_EDGE;
			}
            nmbVertices++;
		}

    void add_edge(int i, int j, int weight)throw (runtime_error)
		{
		    if((i >= maxVertices) || (j >= maxVertices)){
                throw runtime_error("Graph out of bonds.");
		    }
			edges[i][j] = weight;
		}

    int weight(int i, int j)
			// If edge from fromVertex to toVertex exists, returns the weight of edge;
			// otherwise, returns a special “null-edge” value.
		{
			if((i >= maxVertices) || (j >= maxVertices)){
                throw runtime_error("Graph out of bonds.");
		    }
			return edges[i][j];
		}

    int index_is(Vertex* aVertex)
		{
			int i = 0;
			while (i < nmbVertices)
			{
				if (vertices[i] == aVertex)
					return i;
				i++;
			}
			return -1;
		}

		//bool has_vertex(vertex* aVertex)
		//{

		//}

    void clear_marks()
		{
			for (int i=0;i<maxVertices;i++)
				marks[i] = false;
		}

    void mark_vertex(int v)
		{
			marks[v] = true;
		}

    bool is_marked(int v)
		// Returns true if vertex is marked; otherwise, returns false.
		{
			return marks[v];
		}

    int get_unmarked()
		{
			for (int i=0; i<nmbVertices; i++)
			{
				if (marks[i] == false)
					return i;
			}
			return 0;
		}

    int first(int v){
        for(int i= 0; i != nmbVertices; i++){
            if(edges[v][i] != NULL_EDGE){
                return i;
            }
        }
        return nmbVertices;
    }

    int next(int v, int w){
        for(int i= w+1; i != nmbVertices; i++){
            if(edges[v][i] != NULL_EDGE){
                return i;
            }
        }
        return nmbVertices;
    }

    int firstPathedNeighbor(int v){
        for(int i= 0; i != nmbVertices; i++){
            if(edges[v][i] == 2){
                return i;
            }
        }
        return nmbVertices;
    }

    int nextPathedNeighbor(int v, int w){
        for(int i= w+1; i != nmbVertices; i++){
            if(edges[v][i] == 2){
                return i;
            }
        }
        return nmbVertices;
    }

    bool allNeighborsMarked(int v){
        LinkedList<int> neighbors= getNeighbors(v);
        for(neighbors.goToStart(); neighbors.getPos() != neighbors.getSize(); neighbors.next()){
            if(is_marked(neighbors.getElement()) == false){
                return false;
            }
        }
        return true;
    }

    int randNotMarkedNeighbor(int v){
        LinkedList<int> neighbors= getNeighbors(v);
        int index= 0 + (rand() % neighbors.getSize());
        neighbors.goToPos(index);
        while(is_marked(neighbors.getElement())){
            index= 0 + (rand() % neighbors.getSize());
            neighbors.goToPos(index);
        }
        return neighbors.getElement();
    }

    int n(){
        return nmbVertices;
    }

    Vertex* getVertex(int w){
        return vertices[w];
    }

    void DFS(Vertex* aVertex)
        {
			int ix,ix2;
			if (aVertex == NULL) return;

			cout << aVertex->weight() << " ";
			ix = index_is(aVertex);
			marks[ix] = true;

            for (int i=0; i<nmbVertices; i++)
            {
                ix2 = index_is(vertices[i]);
                if (edges[ix][ix2] != NULL_EDGE)	// if adj vertex
                {
                    if (marks[i] == false)
                        DFS(vertices[i]);
                }
            }
        }

    void BFS(Vertex* aVertex)
        {
            int ix, ix2;
            queue <Vertex*> que;
            ix = index_is(aVertex);
            marks[ix] = true;
            que.push(aVertex);

            while (!que.empty())
            {
                Vertex* node = que.front();
                que.pop();
                ix = index_is(node);
                cout << node->weight() << " ";
                for (int i=0; i<nmbVertices; i++)
                {
                    ix2 = index_is(vertices[i]);
                    if (edges[ix][ix2] != NULL_EDGE)	// if adj vertex
                    {
                        if (marks[i] == false)
                        {
                            marks[i] = true;
                            que.push(vertices[i]);
                        }
                    }
                }
            }
        }
};

#endif // WEIGHTEDGRAPH_H
