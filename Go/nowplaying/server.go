package main

import (
	"io"
	"net/http"
	"log"
	"fmt"
)

// hello world, the web server
func NowPlaying(w http.ResponseWriter, req *http.Request) {
	io.WriteString(w, "OK\n")

	data_type := req.FormValue("type")

	if data_type == "ITEM" {
		fmt.Println("Item:")
		fmt.Println(req.FormValue("index"))
		fmt.Println(req.FormValue("album"))
		fmt.Println(req.FormValue("artist"))
		fmt.Println(req.FormValue("title"))
		fmt.Println(req.FormValue("playlist"))
	} else {
		fmt.Println("List:")
		fmt.Println(req.FormValue("album"))
		fmt.Println(req.FormValue("artist"))
		fmt.Println(req.FormValue("list"))
	}
}

func main() {
	http.HandleFunc("/nowplaying", NowPlaying)
	err := http.ListenAndServe(":12345", nil)
	if err != nil {
		log.Fatal("ListenAndServe: ", err)
	}
}
