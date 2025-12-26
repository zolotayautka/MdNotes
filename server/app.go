package main

import (
	"bytes"
	"time"

	"github.com/yuin/goldmark"
)

// Node represents a note/document.
type Node struct {
	LocalID  int     `json:"local_id"`
	GlobalID int     `json:"global_id"`
	Name     string  `json:"name"`
	Naiyou   *string `json:"naiyou,omitempty"`

	Revison   int  `json:"revison"`
	IsShared  bool `json:"is_shared"`
	Dirty     bool `json:"dirty"`
	IsDeleted bool `json:"is_deleted"`

	CreatedAt time.Time `json:"created_at"`
	UpdatedAt time.Time `json:"updated_at"`
}

// ReturnHTML converts the Markdown stored in Naiyou to HTML.
func (n *Node) ReturnHTML() (string, error) {
	if n == nil || n.Naiyou == nil || *n.Naiyou == "" {
		return "", nil
	}
	var buf bytes.Buffer
	if err := goldmark.Convert([]byte(*n.Naiyou), &buf); err != nil {
		return "", err
	}
	return buf.String(), nil
}
