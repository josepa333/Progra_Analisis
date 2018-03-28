#ifndef VERTEX_H
#define VERTEX_H


class Vertex
{
private:
    int wt;
    int x;
    int y;

public:
    Vertex(int w, int coordinateX, int coordinateY)
    {
        wt= w;
        x= coordinateX;
        y= coordinateY;
    }

    int weight()
    {
        return wt;
    }

    int coordinateX()
    {
        return x;
    }

    int coordinateY()
    {
        return y;
    }
};

#endif // VERTEX_H
